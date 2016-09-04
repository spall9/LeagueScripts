////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;
using T2IN1_Sona.Summoners;

namespace T2IN1_Sona.Modes
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
            Interrupter.OnInterruptableSpell += Auto.Interruptererer;
            Orbwalker.OnPreAttack += Active.Orbwalker_OnPreAttack;
            Game.OnWndProc += Active.Game_OnWndProc;

            EventManager.SmartE(null);
            KillSteal.Execute();
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;
            var target = TargetSelector.GetTarget(1200, DamageType.Magical);

            SonaPassive.Passive();
            SonaPassive.GetPassiveCount();
            Auto.AutoW();
            Active.Defensive();
            Active.Defensive2();
            Active.Potions();
            KillSteal.Execute();

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.Execute();

            if (target != null)
            {
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                    Harass.Execute();
                else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                    LaneClear.LaneClearLogic();
                else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                {
                }
                else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
                    Flee.Execute();
                {
                    if (!Menus.FleeMenu["UE"].Cast<CheckBox>().CurrentValue ||
                        (Menus.ComboMenu["COE"].Cast<CheckBox>().CurrentValue &&
                         !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)))
                        return;
                    foreach (
                        var enemy in
                        ObjectManager.Get<AIHeroClient>()
                            .Where(a => a.IsEnemy && a.IsValidTarget(Spells.Exhaust.Range))
                            .Where(
                                enemy =>
                                        Menus.ComboMenu[enemy.ChampionName + "exhaust"].Cast<CheckBox>().CurrentValue))
                    {
                        if (enemy.IsFacing(SpellsManager.Sona))
                        {
                            if (!(SpellsManager.Sona.HealthPercent < 50)) continue;
                            Spells.Exhaust.Cast(enemy);
                            return;
                        }
                        if (!(enemy.HealthPercent < 50)) continue;
                        Spells.Exhaust.Cast(enemy);
                        return;
                    }
                }
            }
        }
    }
}
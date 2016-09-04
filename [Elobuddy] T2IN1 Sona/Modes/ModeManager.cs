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
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.Spells;
using static T2IN1_Sona.SpellsManager;
using static T2IN1_Sona.Active;
using static T2IN1_Sona.Auto;

namespace T2IN1_Sona
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
            Interrupter.OnInterruptableSpell += Interruptererer;
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Game.OnWndProc += Game_OnWndProc;

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
                    if (!FleeMenu["UE"].Cast<CheckBox>().CurrentValue ||
                        ComboMenu["COE"].Cast<CheckBox>().CurrentValue &&
                        !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                        return;
                    foreach (
                        var enemy in
                            ObjectManager.Get<AIHeroClient>()
                                .Where(a => a.IsEnemy && a.IsValidTarget(Exhaust.Range))
                                .Where(
                                    enemy =>
                                        SupportMenu[enemy.ChampionName + "exhaust"].Cast<CheckBox>().CurrentValue))
                    {
                        if (enemy.IsFacing(Sona))
                        {
                            if (!(Sona.HealthPercent < 50)) continue;
                            Exhaust.Cast(enemy);
                            return;
                        }
                        if (!(enemy.HealthPercent < 50)) continue;
                        Exhaust.Cast(enemy);
                        return;
                    }
                }
            }
        }
    }
}
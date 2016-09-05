////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Sona.Base.SpellsManager;
using static T2IN1_Sona.Summoners.Spells;
using static T2IN1_Sona.Base.Menus;


namespace T2IN1_Sona.Modes
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
        }

        private static void Game_OnTick(EventArgs args)
        {
            SonaPassive.Passive();
            Auto.AutoW();
            Active.Defensive();
            Active.Defensive2();
            Active.Potions();
            KillSteal.Execute();

            var target = TargetSelector.GetTarget(1200, DamageType.Magical);

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.Execute();

            if (target != null)
            {
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                    Harass.Execute();
                else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                    LaneClear.LaneClearExecute();
                else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                {
                }
                else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
                    Flee.Execute();
                {
                    if (!FleeMenu["UE"].Cast<CheckBox>().CurrentValue ||
                        (ComboMenu["COE"].Cast<CheckBox>().CurrentValue &&
                         !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)))
                        return;

                    foreach (
                        var enemy in
                        ObjectManager.Get<AIHeroClient>()
                            .Where(a => a.IsEnemy && a.IsValidTarget(Exhaust.Range))
                            .Where(enemy => ComboMenu[enemy.ChampionName + "exhaust"].Cast<CheckBox>().CurrentValue))
                    {
                        if (enemy.IsFacing(Sona))
                        {
                            if (!(Sona.HealthPercent < 50)) continue;
                            {
                                Exhaust.Cast(enemy);
                                return;
                            }
                        }
                        if (!(enemy.HealthPercent < 50)) continue;
                        {
                            Exhaust.Cast(enemy);
                            return;
                        }
                    }
                }
            }
        }

        public static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear)
                || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit)
                || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass)
                || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                var t = target as Obj_AI_Minion;
                if (t != null)
                    if (SupportMenu["Sup"].Cast<CheckBox>().CurrentValue)
                        args.Process = false;
            }
        }
    }
}
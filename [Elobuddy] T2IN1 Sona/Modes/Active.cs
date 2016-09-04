////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.Consumables;
using static T2IN1_Sona.Defensive;
using static T2IN1_Sona.SpellsManager;

namespace T2IN1_Sona
{
    internal class Active
    {
        public static void AutoW()
        {
            var healAllies = MiscMenu["HPLA"].Cast<CheckBox>().CurrentValue;
            var healHealthPercent = MiscMenu["wS"].Cast<Slider>().CurrentValue;

            if (healAllies)
            {
                var ally = EntityManager.Heroes.Allies.FirstOrDefault(x => x.IsValidTarget(W.Range) && x.HealthPercent < healHealthPercent);

                if (ally != null)
                {
                    W.Cast();
                }
            }
        }

        public static int GetPassiveCount()
        {
            foreach (var buff in Sona.Buffs)
            if (buff.Name == "SPC") return buff.Count;
            return 0;
        }

        public static void Passive()
        {
            var unit = TargetSelector.GetTarget(550, DamageType.Magical);
            if ((Q.IsReady() && GetPassiveCount() == 2 && unit.Distance(Sona) <= 550))
            {
                if (Q.IsReady()) Q.Cast();
                Player.IssueOrder(GameObjectOrder.AttackUnit, unit);
            }
        }

        public static void Game_OnWndProc(WndEventArgs args)
        {
            if (args.Msg != (uint)WindowMessages.LeftButtonDown)
            {
                return;
            }
            SelectedHero = EntityManager.Heroes.Enemies.FindAll(hero => hero.IsValidTarget() && hero.Distance(Game.CursorPos, true) < 39999).OrderBy(h => h.Distance(Game.CursorPos, true)).FirstOrDefault();
        }

        public static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                var t = target as Obj_AI_Minion;
                if (t != null)
                {
                    {
                        if (MiscMenu["Sup"].Cast<CheckBox>().CurrentValue)
                            args.Process = false;
                    }
                }
            }
        }

        public static void Interruptererer(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            var intTarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            {
                if (R.IsReady() && sender.IsValidTarget(R.Range) &&
                    MiscMenu["int"].Cast<CheckBox>().CurrentValue)
                    R.Cast(intTarget.ServerPosition);
            }
        }

        #region Defensive Items Cast only if Enemy is in Range

        public static void Defensive()
        {
            //Zhonyas
            if (ActiveMenu["Zhonyas"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(700) >= 1) && Zhonyas.IsOwned() && Zhonyas.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.ZyHp"].Cast<Slider>().CurrentValue)
                        Zhonyas.Cast();
            }
            //Seraph
            if (ActiveMenu["Seraph"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(650) >= 1) && Seraph.IsOwned() && Seraph.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.SeraphHp"].Cast<Slider>().CurrentValue)
                        Seraph.Cast();
            }
            //Solari
            if (ActiveMenu["Solari"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(600) >= 1) && Solari.IsOwned() && Solari.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.SolariHp"].Cast<Slider>().CurrentValue)
                        Solari.Cast();
            }
            //Face
            var Ally =
                EntityManager.Heroes.Allies.Where(
                        a => a.HealthPercent <= ActiveMenu["Item.FaceHP"].Cast<Slider>().CurrentValue)
                    .FirstOrDefault(a => a.IsValidTarget(Face.Range));

            if (ActiveMenu["Face"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Face.IsOwned() && Face.IsReady() && Ally.IsValid)
                    Face.Cast(Ally);
            }
        }

        #endregion Defensive Items Cast only if Enemy is in Range

        #region Defensive Items Cast

        public static void Defensive2()
        {
            //Zhonyas
            if (ActiveMenu["Zhonyas2"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Zhonyas.IsOwned() && Zhonyas.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.ZyHp2"].Cast<Slider>().CurrentValue)
                        Zhonyas.Cast();
            }
            //Seraph
            if (ActiveMenu["Seraph2"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Seraph.IsOwned() && Seraph.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.SeraphHp2"].Cast<Slider>().CurrentValue)
                        Seraph.Cast();
            }
            //Solari
            if (ActiveMenu["Solari2"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Solari.IsOwned() && Solari.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.SolariHp2"].Cast<Slider>().CurrentValue)
                        Solari.Cast();
            }
        }

        #endregion Defensive Items Cast

        #region Consumables Cast

        //Cast Potions
        public static void Potions()
        {
            var HealBuff = Player.HasBuff("RegenerationPotion")
                           || Player.HasBuff("ItemMiniRegenPotion")
                           || Player.HasBuff("ItemCrystalFlask")
                           || Player.HasBuff("ItemDarkCrystalFlask")
                           || Player.HasBuff("ItemCrystalFlaskJungle")
                           || Player.Instance.IsRecalling();

            //Health Potion
            if (ActiveMenu["HealthPotion"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Health.IsOwned() && Health.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.HealthPotionHp"].Cast<Slider>().CurrentValue)
                        Health.Cast();
            }
            //Hunters Potion
            if (ActiveMenu["HuntersPotion"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Hunters.IsOwned() && Hunters.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.HuntersPotionHp"].Cast<Slider>().CurrentValue)
                        Hunters.Cast();
            }

            //Biscuit
            if (ActiveMenu["Biscuit"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;
                {
                    if (Biscuit.IsOwned() && Biscuit.IsReady())
                        if (Player.Instance.HealthPercent <= ActiveMenu["Item.BiscuitHp"].Cast<Slider>().CurrentValue)
                            Biscuit.Cast();
                }
            }

            //Refillable
            if (ActiveMenu["Refillable"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Refillable.IsOwned() && Refillable.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.RefillableHp"].Cast<Slider>().CurrentValue)
                        Refillable.Cast();
            }

            //Corrupting
            if (ActiveMenu["Corrupting"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Corrupting.IsOwned() && Corrupting.IsReady())
                    if (Player.Instance.HealthPercent <= ActiveMenu["Item.CorruptingHp"].Cast<Slider>().CurrentValue)
                        Corrupting.Cast();
            }
        }

        #endregion Consumables Cast
    }
}
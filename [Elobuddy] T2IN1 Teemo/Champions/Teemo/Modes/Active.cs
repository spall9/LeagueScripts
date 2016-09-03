////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.Consumables;
using static T2IN1_Teemo.Defensive;

namespace T2IN1_Teemo
{
    internal class Active
    {
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
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;
using T2IN1_Sona.Items;

namespace T2IN1_Sona.Modes
{
    internal class Active
    {
        #region Defensive Items Cast only if Enemy is in Range

        public static void Defensive()
        {
            //Zhonyas
            if (Menus.ActiveMenu["Zhonyas"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(700) >= 1) && Items.Defensive.Zhonyas.IsOwned() &&
                    Items.Defensive.Zhonyas.IsReady())
                    if (Player.Instance.HealthPercent <= Menus.ActiveMenu["Item.ZyHp"].Cast<Slider>().CurrentValue)
                        Items.Defensive.Zhonyas.Cast();
            }
            //Seraph
            if (Menus.ActiveMenu["Seraph"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(650) >= 1) && Items.Defensive.Seraph.IsOwned() &&
                    Items.Defensive.Seraph.IsReady())
                    if (Player.Instance.HealthPercent <= Menus.ActiveMenu["Item.SeraphHp"].Cast<Slider>().CurrentValue)
                        Items.Defensive.Seraph.Cast();
            }
            //Solari
            if (Menus.ActiveMenu["Solari"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(600) >= 1) && Items.Defensive.Solari.IsOwned() &&
                    Items.Defensive.Solari.IsReady())
                    if (Player.Instance.HealthPercent <= Menus.ActiveMenu["Item.SolariHp"].Cast<Slider>().CurrentValue)
                        Items.Defensive.Solari.Cast();
            }
            //Face
            var Ally =
                EntityManager.Heroes.Allies.Where(
                        a => a.HealthPercent <= Menus.ActiveMenu["Item.FaceHP"].Cast<Slider>().CurrentValue)
                    .FirstOrDefault(a => a.IsValidTarget(Items.Defensive.Face.Range));

            if (Menus.ActiveMenu["Face"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Items.Defensive.Face.IsOwned() && Items.Defensive.Face.IsReady() && Ally.IsValid)
                    Items.Defensive.Face.Cast(Ally);
            }
        }

        #endregion Defensive Items Cast only if Enemy is in Range

        #region Defensive Items Cast

        public static void Defensive2()
        {
            //Zhonyas
            if (Menus.ActiveMenu["Zhonyas2"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Items.Defensive.Zhonyas.IsOwned() && Items.Defensive.Zhonyas.IsReady())
                    if (Player.Instance.HealthPercent <= Menus.ActiveMenu["Item.ZyHp2"].Cast<Slider>().CurrentValue)
                        Items.Defensive.Zhonyas.Cast();
            }
            //Seraph
            if (Menus.ActiveMenu["Seraph2"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Items.Defensive.Seraph.IsOwned() && Items.Defensive.Seraph.IsReady())
                    if (Player.Instance.HealthPercent <= Menus.ActiveMenu["Item.SeraphHp2"].Cast<Slider>().CurrentValue)
                        Items.Defensive.Seraph.Cast();
            }
            //Solari
            if (Menus.ActiveMenu["Solari2"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if (Items.Defensive.Solari.IsOwned() && Items.Defensive.Solari.IsReady())
                    if (Player.Instance.HealthPercent <= Menus.ActiveMenu["Item.SolariHp2"].Cast<Slider>().CurrentValue)
                        Items.Defensive.Solari.Cast();
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
            if (Menus.ActiveMenu["HealthPotion"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Consumables.Health.IsOwned() && Consumables.Health.IsReady())
                    if (Player.Instance.HealthPercent <=
                        Menus.ActiveMenu["Item.HealthPotionHp"].Cast<Slider>().CurrentValue)
                        Consumables.Health.Cast();
            }
            //Hunters Potion
            if (Menus.ActiveMenu["HuntersPotion"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Consumables.Hunters.IsOwned() && Consumables.Hunters.IsReady())
                    if (Player.Instance.HealthPercent <=
                        Menus.ActiveMenu["Item.HuntersPotionHp"].Cast<Slider>().CurrentValue)
                        Consumables.Hunters.Cast();
            }

            //Biscuit
            if (Menus.ActiveMenu["Biscuit"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;
                {
                    if (Consumables.Biscuit.IsOwned() && Consumables.Biscuit.IsReady())
                        if (Player.Instance.HealthPercent <=
                            Menus.ActiveMenu["Item.BiscuitHp"].Cast<Slider>().CurrentValue)
                            Consumables.Biscuit.Cast();
                }
            }

            //Refillable
            if (Menus.ActiveMenu["Refillable"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Consumables.Refillable.IsOwned() && Consumables.Refillable.IsReady())
                    if (Player.Instance.HealthPercent <=
                        Menus.ActiveMenu["Item.RefillableHp"].Cast<Slider>().CurrentValue)
                        Consumables.Refillable.Cast();
            }

            //Corrupting
            if (Menus.ActiveMenu["Corrupting"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Consumables.Corrupting.IsOwned() && Consumables.Corrupting.IsReady())
                    if (Player.Instance.HealthPercent <=
                        Menus.ActiveMenu["Item.CorruptingHp"].Cast<Slider>().CurrentValue)
                        Consumables.Corrupting.Cast();
            }
        }

        #endregion Consumables Cast
    }
}
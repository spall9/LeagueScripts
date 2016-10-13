using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Linq;
using T2IN1_Lib;
using static T2IN1_Wukong.Combo;
using static T2IN1_Wukong.Extensions;
using static T2IN1_Wukong.Menus;
using static T2IN1_Wukong.SpellsManager;
using static T2IN1_Wukong.Potions;

namespace T2IN1_Wukong
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        public static void Game_OnTick(EventArgs args)
        {
            if (player.IsDead || MenuGUI.IsChatOpen || player.IsRecalling())
                return;
            else
            {
                var orbMode = Orbwalker.ActiveModesFlags;
                var playerMana = Player.Instance.ManaPercent;

                if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                    wGapCloser();

                if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && (Player.Instance.CountEnemiesInRange(650) >= 1))
                    ExecuteCombo();

                if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear))
                    JungleClear.Execute();

                if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                    (playerMana > LaneClearMenu.GetSliderValue("manaSlider")))
                    LaneClear.Execute();
            }

            var HealBuff = Player.HasBuff("RegenerationPotion")
                           || Player.HasBuff("ItemMiniRegenPotion")
                           || Player.HasBuff("ItemCrystalFlask")
                           || Player.HasBuff("ItemDarkCrystalFlask")
                           || Player.HasBuff("ItemCrystalFlaskJungle")
                           || Player.Instance.IsRecalling();

            //Health Potion
            if (JungleClearMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Health.IsOwned() && Health.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Health.Cast();
            }
            //Hunters Potion
            if (JungleClearMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Hunters.IsOwned() && Hunters.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Hunters.Cast();
            }

            //Biscuit
            if (JungleClearMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;
                if (Biscuit.IsOwned() && Biscuit.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Biscuit.Cast();
            }

            //Refillable
            if (JungleClearMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Refillable.IsOwned() && Refillable.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Refillable.Cast();
            }

            //Corrupting
            if (JungleClearMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Corrupting.IsOwned() && Corrupting.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Corrupting.Cast();
            }
        }
    }
}
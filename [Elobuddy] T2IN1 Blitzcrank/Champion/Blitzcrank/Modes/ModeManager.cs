﻿using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Blitzcrank.Combo;
using static T2IN1_Blitzcrank.Extensions;
using static T2IN1_Blitzcrank.Menus;
using static T2IN1_Blitzcrank.Potions;

namespace T2IN1_Blitzcrank
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

            var orbMode = Orbwalker.ActiveModesFlags;

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && (Player.Instance.CountEnemiesInRange(1000) >= 1))
                ExecuteCombo();


            var HealBuff = Player.HasBuff("RegenerationPotion")
                           || Player.HasBuff("ItemMiniRegenPotion")
                           || Player.HasBuff("ItemCrystalFlask")
                           || Player.HasBuff("ItemDarkCrystalFlask")
                           || Player.HasBuff("ItemCrystalFlaskJungle")
                           || Player.Instance.IsRecalling();

            //Health Potion
            if (ConsumablesMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Health.IsOwned() && Health.IsReady())
                    if (Player.Instance.HealthPercent <= ConsumablesMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Health.Cast();
            }
            //Hunters Potion
            if (ConsumablesMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Hunters.IsOwned() && Hunters.IsReady())
                    if (Player.Instance.HealthPercent <= ConsumablesMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Hunters.Cast();
            }

            //Biscuit
            if (ConsumablesMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;
                if (Biscuit.IsOwned() && Biscuit.IsReady())
                    if (Player.Instance.HealthPercent <= ConsumablesMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Biscuit.Cast();
            }

            //Refillable
            if (ConsumablesMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Refillable.IsOwned() && Refillable.IsReady())
                    if (Player.Instance.HealthPercent <= ConsumablesMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Refillable.Cast();
            }

            //Corrupting
            if (ConsumablesMenu["usePotions"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Corrupting.IsOwned() && Corrupting.IsReady())
                    if (Player.Instance.HealthPercent <= ConsumablesMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Corrupting.Cast();
            }
        }
    }
}
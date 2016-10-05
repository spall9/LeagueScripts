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

namespace T2IN1_Wukong
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
            Gapcloser.OnGapcloser += AntiGapcloser_OnEnemyGapcloser;
        }

        public static void Game_OnTick(EventArgs args)
        {
            if (player.IsDead || MenuGUI.IsChatOpen || player.IsRecalling())
                return;
            else
            {
                var orbMode = Orbwalker.ActiveModesFlags;
                var playerMana = Player.Instance.ManaPercent;

                if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && (Player.Instance.CountEnemiesInRange(650) >= 1))
                    ExecuteCombo();

                if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear))
                    JungleClear.Execute();

                if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                    (playerMana > LaneClearMenu.GetSliderValue("manaSlider")))
                    LaneClear.Execute();
            }
        }

        public static void AntiGapcloser_OnEnemyGapcloser(AIHeroClient Sender, Gapcloser.GapcloserEventArgs args)
        {
            var playerMana = Player.Instance.ManaPercent;

            //GapCloser
            if (RIsActive())
                return;
            else
                if (ComboMenu["wGapCloser"].Cast<CheckBox>().CurrentValue && (playerMana > ComboMenu.GetSliderValue("manaSlider")))
                if (Sender != null && W.IsReady() && Sender.IsEnemy && Sender.IsValidTarget(Q.Range))
                    W.Cast();
        }
    }
}
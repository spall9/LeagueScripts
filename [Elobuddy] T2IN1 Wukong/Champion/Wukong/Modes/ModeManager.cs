using EloBuddy;
using EloBuddy.SDK;
using System;
using T2IN1_Lib;
using static T2IN1_Wukong.Menus;

namespace T2IN1_Wukong
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && (Player.Instance.CountEnemiesInRange(650) >= 1))
                Combo.ExecuteCombo();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear))
                JungleClear.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                (playerMana > LaneClearMenu.GetSliderValue("manaSlider")))
                LaneClear.Execute();
        }
    }
}
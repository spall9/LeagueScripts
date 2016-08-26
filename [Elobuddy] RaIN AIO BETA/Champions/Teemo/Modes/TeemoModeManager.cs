using System;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;

using static T2IN1.TeemoSpells;
using static T2IN1.TeemoMenu;

namespace T2IN1
{
    internal class TeemoModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;

            Active.TeemoActive();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                TeemoCombo.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit) && playerMana > LasthitMenu.GetSliderValue("manaSlider"))
            {
                LastHit.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && playerMana > LaneClearMenu.GetSliderValue("manaSlider"))
            {
                TeemoLaneClear.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Flee) && playerMana > LasthitMenu.GetSliderValue("manaSlider"))
            {
                TeemoFlee.Execute();
            }
        }
    }
}
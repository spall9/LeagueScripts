////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Lib;
using static T2IN1_Sona.Menus;

namespace T2IN1_Sona
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

            Active.Defensive();
            Active.Defensive2();
            Active.Potions();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.ExecuteItems();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit) &&
                (playerMana > LastHitMenu.GetSliderValue("manaSlider")))
                LastHit.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                (playerMana > LaneClearMenu.GetSliderValue("manaSlider")))
                LaneClear.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Flee) && (playerMana > LastHitMenu.GetSliderValue("manaSlider")))
                Flee.Execute();
        }
    }
}
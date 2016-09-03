////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using EloBuddy;
using static T2IN1_Teemo.SpellsManager;


namespace T2IN1_Teemo
{
    internal static class rRangeLevel
    {
        public static void LevelRRange()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            R.Range = (uint) GetRRange();
        }
    }
}
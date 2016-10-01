////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using EloBuddy;
using EloBuddy.SDK.Events;
using System;
using T2IN1_SkinChanger;
using TextColor = System.Drawing.Color;

namespace T2IN1
{
    internal class Loader
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Teemo
            if (Player.Instance.Hero == Champion.Teemo)
            {


            }
            else
            {
                SkinChanger.CreateMenu();

                Chat.Print("[T2IN1] " + ObjectManager.Player.ChampionName + " is not Supported!", TextColor.PaleVioletRed);
                Chat.Print("[T2IN1] Loading T2IN1 Skin Changer.", TextColor.Blue);
            }
        }
    }
}

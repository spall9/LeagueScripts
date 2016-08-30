////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using EloBuddy;
using EloBuddy.SDK.Events;

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
                T2IN1_Teemo.SpellsManager.InitializeSpells();
                T2IN1_Teemo.Menus.CreateMenu();
                T2IN1_Teemo.ModeManager.InitializeModes();
                T2IN1_Teemo.DrawingsManager.InitializeDrawings();

                Chat.Print("T2IN1 Teemo Loaded!");
                Chat.Print("Credits to MarioGK for his Template & Lib also Credits to Joker for Parts of his Lib");
            }
        }
    }
}
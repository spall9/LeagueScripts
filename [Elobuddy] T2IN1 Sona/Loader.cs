////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using T2IN1_Sona;

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
            //Sona
            if (Player.Instance.Hero == Champion.Sona)
            {
                SpellsManager.InitializeSpells();
                Menus.CreateMenu();
                ModeManager.InitializeModes();
                DrawingsManager.InitializeDrawings();

                Chat.Print("T2IN1 Teemo Loaded!");
                Chat.Print("Credits to MarioGK for his Template & Lib also Credits to Joker for Parts of his Lib");
            }
        }
    }
}
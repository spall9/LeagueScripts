﻿using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace T2IN1
{
    internal class Loader
    {
        /// The firs thing that runs on RaIN AIO
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        /// This event is triggered when the game loads
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Teemo
            if (Player.Instance.Hero == Champion.Teemo)
            {
                TeemoMenu.CreateMenu();
                TeemoDrawings.InitializeDrawings();
                TeemoSpells.InitializeSpells();
                TeemoModeManager.InitializeModes();

                Chat.Print("T2IN1 AIO Teemo Loaded!");
                Chat.Print("Credits to MarioGK for his Addon Template");
                Chat.Print("Thanks to: MarioGK, scarEl");
            }
        }
    }
}
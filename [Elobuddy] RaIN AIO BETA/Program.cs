using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace RaINAIO
{
    internal class Program
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
                TeemoSpellManager.InitializeSpells();
                TeemoMenus.CreateMenu();
                TeemoDrawingsManager.InitializeDrawings();
                TeemoSpellManager.ComboSpells();
                Chat.Print("!BETA VERSION!");
                Chat.Print("RaIN AIO Teemo Loaded!");
                Chat.Print("Credits to MarioGK for his Addon Template");
            }
        }
    }
}
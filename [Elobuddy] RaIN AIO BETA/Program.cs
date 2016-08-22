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
                TeemoSpellsManager.InitializeSpells();
                TeemoMenus.CreateMenu();
                TeemoDrawingsManager.InitializeDrawings();
                TeemoCombo.Combo();
            }

            //Viktor
            if (Player.Instance.Hero == Champion.Viktor)
            {
                ViktorSpellsManager.InitializeSpells();
                ViktorMenus.CreateMenu();
                ViktorDrawingsManager.InitializeDrawings();
                ViktorCombo.Combo();
            }
        }
    }
}
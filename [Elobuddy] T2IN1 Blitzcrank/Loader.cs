using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using T2IN1_Blitzcrank;
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
            //Wukong
            if (Player.Instance.Hero == Champion.Blitzcrank)
            {
                SpellsManager.InitializeSpells();
                Menus.CreateMenu();
                ModeManager.InitializeModes();
                DrawingsManager.InitializeDrawings();
                JungleSteal.Execute();

                Combo.Initialize_E_AA_Reset();

                Chat.Print("[T2IN1] Blitzcrank Loaded!", TextColor.LimeGreen);
            }
            else
            {
                Chat.Print("[T2IN1] " + ObjectManager.Player.ChampionName + " is not Supported!",
                    TextColor.PaleVioletRed);
            }
        }
    }
}
﻿using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using T2IN1_Wukong;
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
            if (Player.Instance.Hero == Champion.MonkeyKing)
            {
                SpellsManager.InitializeSpells();
                Menus.CreateMenu();
                ModeManager.InitializeModes();
                DrawingsManager.InitializeDrawings();
                JungleClear.Init();

                if (ObjectManager.Player.ChampionName.Equals("MonkeyKing"))
                    Chat.Print("[T2IN1] Wukong Loaded!", TextColor.LimeGreen);
                else
                    Chat.Print("[T2IN1] " + ObjectManager.Player.ChampionName + " is not Supported!",
                        TextColor.PaleVioletRed);
            }
        }
    }
}
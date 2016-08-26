﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

using Mario_s_Lib;

namespace T2IN1_Teemo
{
    internal class Menus
    {
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu LaneClearMenu;
        public static Menu KSMenu;
        public static Menu LastHitMenu;
        public static Menu FleeMenu;
        public static Menu ActivatorMenu;
        public static Menu MiscMenu;

        //These colorslider are from Mario`s Lib
        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("T2IN1 " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "Teemo");
            ActivatorMenu = FirstMenu.AddSubMenu("• Activator");
            ComboMenu = FirstMenu.AddSubMenu("• Combo ");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear");
            LastHitMenu = FirstMenu.AddSubMenu("• LastHit");
            KSMenu = FirstMenu.AddSubMenu("• KillSteal");
            FleeMenu = FirstMenu.AddSubMenu("• Flee");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);

            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.Add("R", new CheckBox("- Use R"));
            ComboMenu.CreateSlider("Mana must be higher than [{0}%] to use R in Combo", "manaSlider", 30);
            ComboMenu.AddGroupLabel("Item Settings");
            ComboMenu.Add("Hydra", new CheckBox("- Use Hydra"));

            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("Q", new CheckBox("- Use Q"));
            LaneClearMenu.Add("R", new CheckBox("- Use R"));
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use Lane Clear Spells", "manaSlider", 30);

            LastHitMenu.AddGroupLabel("Last Hit Settings");
            LastHitMenu.Add("Q", new CheckBox("- Use Q"));
            LastHitMenu.CreateSlider("Mana must be higher than [{0}%] to use Last Hit spells", "manaSlider", 45);

            KSMenu.AddGroupLabel("KillSteal Settings");
            KSMenu.Add("Q", new CheckBox("- Use Q"));

            FleeMenu.AddGroupLabel("Flee Settings");
            FleeMenu.Add("W", new CheckBox("- Use W"));

            ActivatorMenu.AddGroupLabel("Activator Settings");
            ActivatorMenu.AddGroupLabel("Use Summoner's");
            ActivatorMenu.Add("Ignite", new CheckBox("- Use Ignite"));
            ActivatorMenu.Add("Smite", new CheckBox("- Use Smite"));
            ActivatorMenu.AddGroupLabel("Use Potion's");
            ActivatorMenu.Add("Biscuit", new CheckBox("- Use Biscuit"));
            ActivatorMenu.Add("Health", new CheckBox("- Use Health"));
            ActivatorMenu.Add("Refillable", new CheckBox("- Use Refillable"));
            ActivatorMenu.Add("Hunters", new CheckBox("- Use Hunters"));
            ActivatorMenu.Add("Corrupting", new CheckBox("- Use Corrupting"));
            ActivatorMenu.AddGroupLabel("Use Offensive Item's");
            ActivatorMenu.Add("Hydra", new CheckBox("- Use Hydra"));
            ActivatorMenu.Add("HydraTitanic", new CheckBox("- Use HydraTitanic"));
            ActivatorMenu.Add("Tiamat", new CheckBox("- Use Tiamat"));
            ActivatorMenu.Add("Cutlass", new CheckBox("- Use Cutlass"));
            ActivatorMenu.Add("Botrk", new CheckBox("- Use Botrk"));
            ActivatorMenu.Add("Youmuu", new CheckBox("- Use Youmuu"));
            ActivatorMenu.Add("Gunblade", new CheckBox("- Use Gunblade"));
            ActivatorMenu.Add("Protobelt", new CheckBox("- Use Protobelt"));
            ActivatorMenu.Add("GLP", new CheckBox("- Use GLP"));
            ActivatorMenu.AddGroupLabel("Use Defensive Item's");
            ActivatorMenu.Add("Zhonyas", new CheckBox("- Use Zhonyas"));
            ActivatorMenu.Add("Seraph", new CheckBox("- Use Seraph"));
            ActivatorMenu.Add("Solari", new CheckBox("- Use Solari"));
            ActivatorMenu.AddGroupLabel("Use Cleanser's");
            ActivatorMenu.Add("Mikael", new CheckBox("- Use Mikael"));
            ActivatorMenu.Add("Qss", new CheckBox("- Use Qss"));
            ActivatorMenu.Add("Mercurial", new CheckBox("- Use Mercurial"));

            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = Mario_s_Lib.DataBases.Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    Player.Instance.SetSkinId(sender.CurrentValue);
                };
            }

            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.CreateCheckBox(" - Draw Spell Range only if Spell is Ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator Percent.", "perDraw");
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator Statistics.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox(" - Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox(" - Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox(" - Draw E.", "eDraw");
            DrawingsMenu.CreateCheckBox(" - Draw R.", "rDraw");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.Red, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.Purple, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Orange, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.DeepPink, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.YellowGreen, "DamageIndicator Color:");

            MiscMenu.AddGroupLabel("Auto Level UP");
            MiscMenu.CreateCheckBox("Activate Auto Leveler", "activateAutoLVL", false);
            MiscMenu.AddLabel("The Auto Leveler will always Focus R than the rest of the Spells");
            MiscMenu.CreateComboBox("1 Spell to Focus", "firstFocus", new List<string> { "Q", "W", "E" });
            MiscMenu.CreateComboBox("2 Spell to Focus", "secondFocus", new List<string> { "Q", "W", "E" }, 1);
            MiscMenu.CreateComboBox("3 Spell to Focus", "thirdFocus", new List<string> { "Q", "W", "E" }, 2);
            MiscMenu.CreateSlider("Delay Slider", "delaySlider", 200, 150, 500);
        }
    }
}
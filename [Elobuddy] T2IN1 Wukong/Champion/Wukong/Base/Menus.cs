using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using T2IN1_Lib;
using T2IN1_Lib.DataBases;

namespace T2IN1_Wukong
{
    internal class Menus
    {
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu LaneClearMenu;
        public static Menu JungleClearMenu;
        public static Menu MiscMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("T2IN1 " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "Wukong");
            ComboMenu = FirstMenu.AddSubMenu("• Combo ");
            LaneClearMenu = FirstMenu.AddSubMenu("• Lane Clear");
            JungleClearMenu = FirstMenu.AddSubMenu("• Jungle Clear");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);

            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.Add("E", new CheckBox("- Use E"));
            ComboMenu.AddSeparator();
            ComboMenu.AddLabel("Experimental");
            ComboMenu.Add("W", new CheckBox("- Use W as Gap Closer", false));
            ComboMenu.Add("expcombo2", new CheckBox("- Use AA Reset with Q", false));
            ComboMenu.AddSeparator();
            ComboMenu.Add("R", new CheckBox("- Use R"));
            ComboMenu.Add("RCount", new Slider("Use R if  {0}  Player(s) in Range", 1, 1, 5));
            //ComboMenu.AddGroupLabel("Summoner Settings");
            //ComboMenu.Add("Smite", new CheckBox("- Use Smite"));
            //ComboMenu.Add("Ignite", new CheckBox("- Use Ignite"));

            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("Q", new CheckBox("- Use Q"));
            LaneClearMenu.Add("W", new CheckBox("- Use W"));
            LaneClearMenu.Add("E", new CheckBox("- Use E"));
            LaneClearMenu.CreateSlider("Mana must be higher than {0}% to use Lane Clear Spells", "manaSlider", 50);

            JungleClearMenu.AddGroupLabel("Jungle Clear Settings");
            JungleClearMenu.Add("Q", new CheckBox("- Use Q"));
            JungleClearMenu.Add("W", new CheckBox("- Use W"));
            JungleClearMenu.Add("E", new CheckBox("- Use E"));
            JungleClearMenu.AddSeparator();
            JungleClearMenu.AddLabel("Auto Smite / Steal Settings");
            JungleClearMenu.Add("AutoSmite", new CheckBox("- Smite/Steal (Dragon, Baron, Herald)"));
            JungleClearMenu.Add("JRed&Blue", new CheckBox("- Smite/Steal Red & Blue Buff"));
            JungleClearMenu.AddSeparator();
            JungleClearMenu.AddGroupLabel("Consumables Settings");
            JungleClearMenu.Add("usePotions", new CheckBox("- Use Potions"));
            JungleClearMenu.CreateSlider("Use Potion's if below {0}% Health", "PotionHp", 35);

            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
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
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.CornflowerBlue, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.White, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.White, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.Red, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.YellowGreen,
                "DamageIndicator Color:");

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
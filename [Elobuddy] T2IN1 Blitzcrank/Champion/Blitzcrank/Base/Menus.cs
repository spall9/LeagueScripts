using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using T2IN1_Lib.DataBases;

namespace T2IN1_Blitzcrank
{
    internal class Menus
    {
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu JungleStealMenu;
        public static Menu MiscMenu;
        public static Menu ConsumablesMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("T2IN1 " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "Blitzcrank");
            ComboMenu = FirstMenu.AddSubMenu("• Combo ");
            JungleStealMenu = FirstMenu.AddSubMenu("• Jungle Steal");
            ConsumablesMenu = FirstMenu.AddSubMenu("• Consumables");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);

            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.CreateSlider("Use Q only if above {0}% Mana", "manaSlider", 45);
            ComboMenu.Add("W", new CheckBox("- Use W"));
            ComboMenu.Add("E", new CheckBox("- Use E"));
            ComboMenu.AddSeparator();
            ComboMenu.Add("R", new CheckBox("- Use R"));
            ComboMenu.Add("RCount", new Slider("Use R if  {0}  Player(s) in Range", 1, 1, 5));
            ComboMenu.AddSeparator();
            ComboMenu.AddLabel("Experimental");
            ComboMenu.Add("aaecombo", new CheckBox("- Use E for AA Reset", false));
            //ComboMenu.AddGroupLabel("Summoner Settings");
            //ComboMenu.Add("Smite", new CheckBox("- Use Smite"));
            //ComboMenu.Add("Ignite", new CheckBox("- Use Ignite"));

            JungleStealMenu.AddGroupLabel("Steal Settings");
            JungleStealMenu.Add("enablesteal", new CheckBox("- Enable Smite Steal (can cause Low FPS!)"));
            JungleStealMenu.AddSeparator();
            JungleStealMenu.Add("AutoSmite", new CheckBox("- Steal (Dragon, Baron, Herald)"));
            JungleStealMenu.Add("JRed&Blue", new CheckBox("- Steal Red & Blue Buff"));

            ConsumablesMenu.AddGroupLabel("Consumables Settings");
            ConsumablesMenu.Add("usePotions", new CheckBox("- Use Potions"));
            ConsumablesMenu.CreateSlider("Use Potion's if below {0}% Health", "PotionHp", 35);

            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                    {
                        Player.Instance.SetSkinId(sender.CurrentValue);
                    };
            }
            DrawingsMenu.AddGroupLabel("Prediction Settings");
            DrawingsMenu.CreateCheckBox(" - Draw Q Prediction.", "QPredictionDraw");
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
            MiscMenu.CreateComboBox("1 Spell to Focus", "firstFocus", new List<string> {"Q", "W", "E"});
            MiscMenu.CreateComboBox("2 Spell to Focus", "secondFocus", new List<string> {"Q", "W", "E"}, 1);
            MiscMenu.CreateComboBox("3 Spell to Focus", "thirdFocus", new List<string> {"Q", "W", "E"}, 2);
            MiscMenu.CreateSlider("Delay Slider", "delaySlider", 200, 150, 500);
        }
    }
}
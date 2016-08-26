using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

using Mario_s_Lib;

namespace T2IN1_Pantheon
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
            FirstMenu = MainMenu.AddMenu("T2IN1 " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "Pantheon");
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
            ComboMenu.Add("W", new CheckBox("- Use W"));
            ComboMenu.Add("E", new CheckBox("- Use E"));
            ComboMenu.Add("R", new CheckBox("- Use R"));

            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("E", new CheckBox("- Use E"));
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use Lane Clear Spells", "manaSlider", 30);

            LastHitMenu.AddGroupLabel("Last Hit Settings");
            LastHitMenu.Add("E", new CheckBox("- Use E"));
            LastHitMenu.CreateSlider("Mana must be higher than [{0}%] to use Last Hit spells", "manaSlider", 45);

            FleeMenu.AddGroupLabel("Flee Settings");
            FleeMenu.AddLabel("Use Ability's");
            FleeMenu.Add("W", new CheckBox("- Use W"));

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
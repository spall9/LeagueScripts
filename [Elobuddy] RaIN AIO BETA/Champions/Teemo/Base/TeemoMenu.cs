using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using Mario_s_Lib.DataBases;

namespace RaINAIO
{
    internal class TeemoMenu
    {
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu LaneClearMenu;
        public static Menu MiscMenu;

        //These colorslider are from Mario`s Lib
        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("RaIN AIO " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "Teemo");
            ComboMenu = FirstMenu.AddSubMenu("• Combo");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear - Not Implemented");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);

            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = Skins.SkinsDB.FirstOrDefault(list => list.Champ == Champion.Teemo);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose Skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args) { Player.Instance.SetSkinId(sender.CurrentValue); };
                Player.Instance.SetSkinId(MiscMenu.Get<ComboBox>("skinComboBox").CurrentValue);
            }

            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.AddLabel("Use Ability");
            ComboMenu.Add("Q", new CheckBox("Use Q - Testing"));
            ComboMenu.Add("W", new CheckBox("Use W - Not Implemented"));
            ComboMenu.Add("R", new CheckBox("Use R - Not Implemented"));

            LaneClearMenu.AddGroupLabel("LaneClear Settings");
            LaneClearMenu.AddLabel("Use Ability");
            LaneClearMenu.Add("Q", new CheckBox("Use Q"));
            LaneClearMenu.Add("R", new CheckBox("Use R"));

            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.CreateCheckBox(" - Draw Spell`s range only if they are ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator percent.", "perDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator statistics.", "statDraw", false);
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
            MiscMenu.AddLabel("The auto leveler will always focus R than the rest of the spells");
            MiscMenu.CreateComboBox("1st Spell to focus", "firstFocus", new List<string> { "Q", "W", "E" });
            MiscMenu.CreateComboBox("2nd Spell to focus", "secondFocus", new List<string> { "Q", "W", "E" }, 1);
            MiscMenu.CreateComboBox("3rd Spell to focus", "thirdFocus", new List<string> { "Q", "W", "E" }, 2);
            MiscMenu.CreateSlider("Delay slider", "delaySlider", 200, 150, 500);
        }
    }
}
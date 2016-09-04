////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using T2IN1_Lib.DataBases;

namespace T2IN1_Sona
{
    internal class Menus
    {
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu LaneClearMenu;
        public static Menu KillStealMenu;
        public static Menu SupportMenu;
        public static Menu FleeMenu;
        public static Menu MiscMenu;
        public static Menu ActiveMenu;
        public static Menu HarassMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("T2IN1 " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "Sona");
            ActiveMenu = FirstMenu.AddSubMenu("• Item Activator");
            ComboMenu = FirstMenu.AddSubMenu("• Combo");
            KillStealMenu = FleeMenu.AddSubMenu("• Kill Steal");
            HarassMenu = FirstMenu.AddSubMenu("• Harass");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear");
            FleeMenu = FirstMenu.AddSubMenu("• Flee");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);
            SupportMenu = FleeMenu.AddSubMenu("• Support");
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);

            KillStealMenu.AddGroupLabel("Kill Steal Settings");
            KillStealMenu.Add("KS", new CheckBox("Kill Steal"));

            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.Add("R", new CheckBox("- Use R"));
            ComboMenu.Add("COE", new CheckBox("Use Exhaust (Combo Only)"));
            ComboMenu.Add("UI", new CheckBox("Use Items"));
            ComboMenu.AddSeparator();
            ComboMenu.Add("rCount", new Slider("Minimum People for R", 1, 0, 5));
            ComboMenu.Add("wAA", new CheckBox("Wait for AA to Finish", false));

            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.Add("QHarass", new CheckBox("Use Q"));
            HarassMenu.Add("wAA", new CheckBox("Wait for AA to Finish", false));

            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("LCQ", new CheckBox("- Use Q"));

            SupportMenu.AddGroupLabel("Support Settings");
            SupportMenu.Add("Sup", new CheckBox("Support Mode", false));
            SupportMenu.Add("IS", new CheckBox("Try to Interrupt Enemy Spell with R"));
            foreach (var source in ObjectManager.Get<AIHeroClient>().Where(a => a.IsEnemy))
                MiscMenu.Add(source.ChampionName + "exhaust",
                    new CheckBox("Exhaust " + source.ChampionName, false));
            SupportMenu.AddSeparator();
            SupportMenu.Add("HPLA", new CheckBox("Use W on % HP Allies to Heal", false));
            SupportMenu.Add("wS", new Slider("Ally Health Percentage to use W", 60));

            FleeMenu.AddGroupLabel("Flee Settings");
            FleeMenu.Add("W", new CheckBox("- Use W"));
            FleeMenu.Add("UE", new CheckBox("Use Exhaust"));

            ActiveMenu.AddGroupLabel("Item Defensive Items Settings");
            ActiveMenu.AddGroupLabel("Only one Option for each Defensive Item can be Active at a Time!");
            ActiveMenu.Add("Zhonyas", new CheckBox("- Use Zhonyas Only if Enemy is in Range"));
            ActiveMenu.Add("Zhonyas2", new CheckBox("- Use Zhonyas", false));
            ActiveMenu.CreateSlider("Use Zhonyas if {0}% Health", "Item.ZyHp", 35);
            ActiveMenu.Add("Seraph", new CheckBox("- Use Seraph Only if Enemy is in Range"));
            ActiveMenu.Add("Seraph2", new CheckBox("- Use Seraph", false));
            ActiveMenu.CreateSlider("Use Seraphs Embrace if {0}% Health", "Item.SeraphHp", 35);
            ActiveMenu.Add("Solari", new CheckBox("- Use Solari Only if Enemy is in Range"));
            ActiveMenu.Add("Solari2", new CheckBox("- Use Solari", false));
            ActiveMenu.CreateSlider("Use Locket of the Iron Solari if {0}% Health", "Item.SolariHp", 35);
            ActiveMenu.Add("Face", new CheckBox("- Use Face"));
            ActiveMenu.CreateSlider("Use Face of the Mountain if {0}% Health", "Item.FaceHp", 35);

            ActiveMenu.AddGroupLabel("Item Consumables Settings");
            ActiveMenu.Add("HealthPotion", new CheckBox("- Use Health Potion"));
            ActiveMenu.CreateSlider("Use Health Potion if below {0}% Health", "Item.HealthPotionHp", 35);
            ActiveMenu.Add("HuntersPotion", new CheckBox("- Use Hunters Potion"));
            ActiveMenu.CreateSlider("Use Hunters if below {0}% Health", "Item.HuntersPotionHp", 35);
            ActiveMenu.Add("Biscuit", new CheckBox("- Use Biscuit"));
            ActiveMenu.CreateSlider("Use Biscuit if below {0}% Health", "Item.BiscuitHp", 35);
            ActiveMenu.Add("Refillable", new CheckBox("- Use Refillable"));
            ActiveMenu.CreateSlider("Use Refillable if below {0}% Health", "Item.RefillableHp", 35);
            ActiveMenu.Add("Corrupting", new CheckBox("- Use Corrupting"));
            ActiveMenu.CreateSlider("Use Corrupting if below {0}% Health", "Item.CorruptingHp", 35);

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
            MiscMenu.AddSeparator();
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
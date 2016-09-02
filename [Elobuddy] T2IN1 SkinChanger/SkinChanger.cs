////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//                             Credits to MarioGK for his Lib & Template                                      //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using T2IN1_SkinChanger.DataBases;
using T2IN1_SkinChanger.MenuHelper;

namespace T2IN1_SkinChanger
{
    internal class SkinChanger
    {
        public static Menu FirstMenu;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("T2IN1 SkinChanger " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "T2IN1");

            var skinList = Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                FirstMenu.CreateComboBox("Choose Skin", "skinComboBox", skinList.Skins);
                FirstMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                    {
                        Player.Instance.SetSkinId(sender.CurrentValue);
                    };
            }
        }
    }
}
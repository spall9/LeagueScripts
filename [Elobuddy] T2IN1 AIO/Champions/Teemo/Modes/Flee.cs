////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
// Credits to MarioGK for his Lib, Template and his Help, also thanks & Credits to Joker for Parts of his Lib //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;

namespace T2IN1_Teemo
{
    internal class Flee
    {
        public static void Execute()
        {
            if (FleeMenu["W"].Cast<CheckBox>().CurrentValue)
            {
                if (W.IsReady())
                {
                    W.Cast();
                }
            }
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy.SDK.Menu.Values;
using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;

namespace T2IN1_Teemo
{
    internal class Flee
    {
        public static void Execute()
        {
            if (FleeMenu["W"].Cast<CheckBox>().CurrentValue)
                if (W.IsReady())
                    W.Cast();
        }
    }
}
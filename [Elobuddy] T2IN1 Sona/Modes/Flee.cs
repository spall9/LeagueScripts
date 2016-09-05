////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Sona.Base.Menus;
using static T2IN1_Sona.Base.SpellsManager;

namespace T2IN1_Sona.Modes
{
    internal class Flee
    {
        public static void Execute()
        {
            if (FleeMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                E.Cast();
                Orbwalker.MoveTo(Game.CursorPos);
            }
        }
    }
}
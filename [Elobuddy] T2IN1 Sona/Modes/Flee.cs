////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;

namespace T2IN1_Sona.Modes
{
    internal class Flee
    {
        public static void Execute()
        {
            if (Menus.FleeMenu["W"].Cast<CheckBox>().CurrentValue)
            {
                SpellsManager.E.Cast();
                Orbwalker.MoveTo(Game.CursorPos);
            }
        }
    }
}
using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal class TeemoFlee
    {
        public static void Execute()
        {
            //Returns true if the Checkbox W is enabled
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
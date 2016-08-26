using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;

namespace T2IN1_Pantheon
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
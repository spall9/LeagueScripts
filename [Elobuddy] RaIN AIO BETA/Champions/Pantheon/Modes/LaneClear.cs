using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;

namespace T2IN1_Pantheon
{
    internal static class LaneClear
    {
        public static void Execute()
        {
            if (LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                E.TryToCast(E.GetBestLinearFarmPosition(minMinionsToHit: 3), LastHitMenu);
            }
        }
    }
}
using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal static class TeemoLaneClear
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetJungleMinion(), LaneClearMenu);
            R.TryToCast(R.GetBestCircularFarmPosition(), LasthitMenu);
        }
    }
}
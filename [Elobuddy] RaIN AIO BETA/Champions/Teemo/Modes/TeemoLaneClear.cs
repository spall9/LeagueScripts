using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1.Extensions;
using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal static class TeemoLaneClear
    {
        public static void Execute()
        {
            var delay = new Random().Next(1000, 5000);

            if (LaneClearMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (R.IsReady())
                {
                    R.TryToCast(R.GetBestCircularFarmPosition(), LaneClearMenu);
                }
            }
            
            if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (Q.IsReady())
                {
                    Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
                }
            }
        }
    }
}
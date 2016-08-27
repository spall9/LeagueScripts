using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;

namespace T2IN1_Teemo
{
    internal static class LaneClear
    {
        public static void Execute()
        {
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
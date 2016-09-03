////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Threading;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using T2IN1_Lib;
using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;
using static T2IN1_Teemo.Offensive;

namespace T2IN1_Teemo
{
    internal static class LaneClear
    {
        public static void Execute()
        {
            if (LaneClearMenu["R"].Cast<CheckBox>().CurrentValue)
                if (Player.Instance.CountEnemyMinionsInRange(900) >= 4 && R.IsReady() && R.IsLearned)
                    R.Cast(R.GetBestCircularFarmPosition(4));

            if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (Player.Instance.CountEnemyMinionsInRange(680) >= 3 && Q.IsReady() && Q.IsLearned)
                    Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy.SDK.Menu.Values;
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
            //Cast R
            if (LaneClearMenu["R"].Cast<CheckBox>().CurrentValue)
                if (R.IsReady())
                    R.TryToCast(R.GetBestCircularFarmPosition(4), LaneClearMenu);

            //Cast Q
            if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (Q.IsReady())
                    Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);

            //Cast Hydra
            if (LaneClearMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
                if (Hydra.IsReady())
                    Hydra.Cast();

            //Cast Tiamat
            if (LaneClearMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
                if (Tiamat.IsReady())
                    Tiamat.Cast();
        }
    }
}
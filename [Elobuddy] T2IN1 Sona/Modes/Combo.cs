////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1;
using T2IN1_Lib;
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.SpellsManager;
using static T2IN1_Sona.Defensive;

namespace T2IN1_Sona
{
    internal static class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Magical);

            if (target == null || !target.IsValid())
            {
                return;
            }

            if (Orbwalker.IsAutoAttacking && ComboMenu["wAA"].Cast<CheckBox>().CurrentValue)
                return;

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (Q.IsReady() && Sona.CountEnemiesInRange(Q.Range) >= 1)
                {
                    Q.Cast();
                }
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
                if (R.IsReady())
                {
                    var predR = R.GetPrediction(target).CastPosition;
                    if (target.CountEnemiesInRange(R.Width) >= ComboMenu["rCount"].Cast<Slider>().CurrentValue)
                        R.Cast(predR);
                }
            if (ComboMenu["UI"].Cast<CheckBox>().CurrentValue)
            {
                if (FrostQueen.IsOwned() && FrostQueen.IsReady())
                    FrostQueen.Cast();
            }
        }
    }
}
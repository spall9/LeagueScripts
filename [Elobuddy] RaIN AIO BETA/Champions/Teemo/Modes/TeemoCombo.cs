using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal static class TeemoCombo
    {
        public static void Execute()
        {
            //Returns TargetSelector Target from the Range set
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            //Return true of Target doesnt exist or null
            if (qtarget == null)
            {
                return;
            }

            //Returns true if the Checkbox Q is enabled
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                //Returns true if Target is valid in Q Range
                if (qtarget.IsValidTarget(Q.Range) && Q.IsReady())
                {
                    //Cast already applies Prediction so its not needed to use Qpred.CastPostion
                    Q.TryToCast(qtarget, ComboMenu);
                }
            }

            //Returns TargetSelector Target from the Range set
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            //Return true of Target doesnt exist or null
            if (rtarget == null)
            {
                return;
            }

            //Returns true if the Checkbox R is enabled
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                //Returns true if Target is valid in R Range
                if (rtarget.IsValidTarget(R.Range) && R.IsReady())
                {
                    //Cast already applies Prediction so its not needed to use Rpred.CastPostion
                    R.TryToCast(rtarget, ComboMenu);
                }
            }
        }
    }
}
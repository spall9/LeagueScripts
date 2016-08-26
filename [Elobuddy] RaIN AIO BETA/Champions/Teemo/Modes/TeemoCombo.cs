using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Spells;
using Mario_s_Lib;

using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal static class TeemoCombo
    {

        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if (qtarget == null)
            {
                return;
            }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (qtarget.IsValidTarget(Q.Range) && Q.IsReady())
                {
                    Q.TryToCast(qtarget, ComboMenu);
                }
            }

            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if (rtarget == null)
            {
                return;
            }
            
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (rtarget.IsValidTarget(R.Range) && R.IsReady())
                {
                    R.TryToCast(rtarget, ComboMenu);
                }
            }
        }
    }
}
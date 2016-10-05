using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Linq;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Wukong.Menus;
using static T2IN1_Wukong.SpellsManager;
using static T2IN1_Wukong.Extensions;

namespace T2IN1_Wukong
{
    internal static class Combo
    {
        public static void ExecuteCombo()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Physical);

            if (RIsActive())
                return;
            else
                if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                        E.TryToCast(etarget, ComboMenu);

            if (RIsActive())
                return;
            else
                if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                    if (Q.IsReady() && Q.IsLearned && qtarget.IsValidTarget(Q.Range))
                        Q.TryToCast(qtarget, ComboMenu);

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && (Player.Instance.CountEnemiesInRange(315) >= ComboMenu["RCount"].Cast<Slider>().CurrentValue))
                if (R.IsReady() && R.IsLearned && rtarget.IsValidTarget(R.Range))
                    R.TryToCast(rtarget, ComboMenu);
        }
    }
}
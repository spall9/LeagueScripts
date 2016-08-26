using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;

namespace T2IN1_Pantheon
{
    internal static class Combo
    {
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);

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

            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);

            if (wtarget == null)
            {
                return;
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
            {
                if (wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.TryToCast(wtarget, ComboMenu);
                }
            }

            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);

            if (etarget == null)
            {
                return;
            }

            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (etarget.IsValidTarget(E.Range) && E.IsReady())
                {
                    E.TryToCast(etarget, ComboMenu);
                }
            }

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (R.IsReady())
                {
                    R.TryToCast(R.GetKillableHero(), ComboMenu);
                }
            }
        }
    }
}
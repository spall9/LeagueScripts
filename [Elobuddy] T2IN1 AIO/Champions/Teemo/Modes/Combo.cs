using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;
using static T2IN1_Teemo.Offensive;

namespace T2IN1_Teemo
{
    internal static class Combo
    {
        public static void Execute1()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if (qtarget == null || qtarget.IsInvulnerable)
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

            //Cast Hydra & Tiamat
            var hydratarget = TargetSelector.GetTarget(Hydra.Range, DamageType.True);

            if (hydratarget == null || hydratarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Hydra"].Cast<CheckBox>().CurrentValue)
            {
                if (hydratarget.IsValidTarget(Hydra.Range) && Hydra.IsReady())
                {
                    Hydra.Cast();
                }
            }

            var tiamattarget = TargetSelector.GetTarget(Tiamat.Range, DamageType.True);

            if (tiamattarget == null || tiamattarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Tiamat"].Cast<CheckBox>().CurrentValue)
            {
                if (tiamattarget.IsValidTarget(Tiamat.Range) && Tiamat.IsReady())
                {
                    Tiamat.Cast();
                }
            }
        }

        public static void Execute2()
        {
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if (rtarget == null || rtarget.IsInvulnerable)
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
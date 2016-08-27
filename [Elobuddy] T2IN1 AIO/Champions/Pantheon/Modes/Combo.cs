using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;
using static T2IN1_Pantheon.Offensive;

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
                    HydraTitanic.Cast();
                }
            }

            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);

            if (etarget == null)
            {
                return;
            }

            //Add Stop Movin Function
            if (ComboMenu["ECancel"].Cast<CheckBox>().CurrentValue)
            {
                if (etarget.IsValidTarget(E.Range) && E.IsReady())
                {
                    E.TryToCast(etarget, ComboMenu);
                }
            }

            //Add Stop Movin Function
            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (etarget.IsValidTarget(E.Range) && E.IsReady())
                {
                    E.TryToCast(etarget, ComboMenu);
                    Orbwalker.DisableAttacking = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
                    Orbwalker.DisableMovement = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
                }
            }

            //Cast Hydra & Tiamat
            var hydratarget = TargetSelector.GetTarget(Hydra.Range, DamageType.True);

            if (hydratarget == null)
            {
                return;
            }

            if (ActivatorMenu["Hydra"].Cast<CheckBox>().CurrentValue)
            {
                if (hydratarget.IsValidTarget(Hydra.Range) && Hydra.IsReady())
                {
                    Hydra.Cast();
                    Tiamat.Cast();
                }
            }
        }
    }
}
using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Wukong.Menus;
using static T2IN1_Wukong.SpellsManager;
using static T2IN1_Wukong.Extensions;

namespace T2IN1_Wukong
{
    internal static class Combo
    {
        public static void Initialize_Q_AA_Reset()
        {
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }

        #region Q AA RESET
        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            var AAResetTarget = target as AIHeroClient;

            if (AAResetTarget == null || !Q.IsReady() || !Player.Instance.IsInAutoAttackRange(AAResetTarget)) return;
            if (ComboMenu["expcombo2"].Cast<CheckBox>().CurrentValue)
            {
                Q.Cast();
                Orbwalker.ResetAutoAttack();
                Player.IssueOrder(GameObjectOrder.AttackTo, AAResetTarget);
            }
        }

        public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe) return;
            if (args.Slot == SpellSlot.Q)
            {
                Orbwalker.ResetAutoAttack();
            }
        }
        #endregion Q AA RESET

        #region GapCloser
        public static void wGapCloser()
        {
            var wtarget = TargetSelector.GetTarget(range: 1100, damageType: DamageType.Physical);

            if (RIsActive())
                return;
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (W.IsReady() && W.IsLearned && wtarget.IsValidTarget(W.Range = 1100))
                    W.TryToCast(wtarget, ComboMenu);
        }
        #endregion GapCloser

        #region Current Combo
        public static void ExecuteCombo1()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Physical);

            if (ComboMenu["expcombo2"].Cast<CheckBox>().CurrentValue)
            {
                if (RIsActive())
                    return;
                if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                {
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                    {
                        E.Cast(etarget);
                    }
                }

                if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && (Player.Instance.CountEnemiesInRange(315) >= ComboMenu["RCount"].Cast<Slider>().CurrentValue))
                {
                    if (R.IsReady() && R.IsLearned && Q.IsOnCooldown && rtarget.IsValidTarget(R.Range))
                    {
                        R.Cast(rtarget);
                    }
                }
            }
            else
            {
                if (RIsActive())
                    return;
                if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                {
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                    {
                        E.Cast(etarget);
                    }
                }

                if (RIsActive())
                    return;
                if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                {
                    if (Q.IsReady() && Q.IsLearned && qtarget.IsValidTarget(Q.Range))
                    {
                        Q.Cast();
                    }
                }

                if (ComboMenu["R"].Cast<CheckBox>().CurrentValue &&
                    (Player.Instance.CountEnemiesInRange(315) >= ComboMenu["RCount"].Cast<Slider>().CurrentValue))
                {
                    if (R.IsReady() && R.IsLearned && rtarget.IsValidTarget(R.Range))
                    {
                        R.Cast(rtarget);
                    }
                }        
            }
        }
        #endregion Current Combo
    }
}
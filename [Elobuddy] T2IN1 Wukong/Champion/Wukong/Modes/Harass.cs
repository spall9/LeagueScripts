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
    internal static class Harass
    {
        public static void Initialize_Q_AA_Reset()
        {
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast_Q;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack_Q;
        }

        #region Gap Closer

        public static void wGapCloser()
        {
            var wtarget = TargetSelector.GetTarget(1100, DamageType.Physical);

            if (RIsActive())
                return;
            if (W.IsReady() && W.IsLearned && wtarget.IsValidTarget(W.Range = 1100))
                W.TryToCast(wtarget, HarassMenu);
        }

        #endregion Gap Closer

        #region Q AA RESET

        public static void OnProcessSpellCast_Q(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe) return;
            if (args.Slot == SpellSlot.Q)
                Orbwalker.ResetAutoAttack();
        }

        public static void Orbwalker_OnPostAttack_Q(AttackableUnit target, EventArgs args)
        {
            var AA_Q_ResetTarget = target as AIHeroClient;

            if ((AA_Q_ResetTarget == null) || !Q.IsReady() || !Player.Instance.IsInAutoAttackRange(AA_Q_ResetTarget))
                return;
            if (HarassMenu["aaqcombo"].Cast<CheckBox>().CurrentValue)
            {
                Q.Cast();
                Orbwalker.ResetAutoAttack();
                Player.IssueOrder(GameObjectOrder.AttackTo, AA_Q_ResetTarget);
            }
        }

        #endregion Q AA RESET

        #region Current Harass

        public static void ExecuteHarass()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var wtarget = TargetSelector.GetTarget(150, DamageType.Physical);

            if (HarassMenu["aaqcombo"].Cast<CheckBox>().CurrentValue)
            {
                if (HarassMenu["E"].Cast<CheckBox>().CurrentValue)
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                        E.Cast(etarget);

                if ((HarassMenu["wGapCloser"].Cast<CheckBox>().CurrentValue == false) &&
                    HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                    if (HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                        if (W.IsReady() && W.IsLearned && Q.IsOnCooldown && wtarget.IsValidTarget(W.Range = 150))
                            W.TryToCast(wtarget, HarassMenu);
            }
            else
            {
                if ((HarassMenu["wGapCloser"].Cast<CheckBox>().CurrentValue == false) &&
                    HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                    if (HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                        if (W.IsReady() && W.IsLearned && wtarget.IsValidTarget(W.Range = 150))
                            W.TryToCast(wtarget, HarassMenu);

                if (HarassMenu["E"].Cast<CheckBox>().CurrentValue)
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                        E.Cast(etarget);

                if (HarassMenu["Q"].Cast<CheckBox>().CurrentValue)
                    if (Q.IsReady() && Q.IsLearned && qtarget.IsValidTarget(Q.Range))
                        Q.Cast();
            }
        }

        #endregion Current Harass
    }
}
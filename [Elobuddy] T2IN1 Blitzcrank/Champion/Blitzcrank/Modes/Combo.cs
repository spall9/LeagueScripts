﻿using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Blitzcrank.Menus;
using static T2IN1_Blitzcrank.SpellsManager;

namespace T2IN1_Blitzcrank
{
    internal static class Combo
    {
        public static void Initialize_E_AA_Reset()
        {
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast_E;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack_E;
        }

        #region E AA RESET

        public static void OnProcessSpellCast_E(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe) return;
            if (args.Slot == SpellSlot.E)
                Orbwalker.ResetAutoAttack();
        }

        public static void Orbwalker_OnPostAttack_E(AttackableUnit target, EventArgs args)
        {
            var AA_E_ResetTarget = target as AIHeroClient;

            if ((AA_E_ResetTarget == null) || !E.IsReady() || !Player.Instance.IsInAutoAttackRange(AA_E_ResetTarget))
                return;
            if (ComboMenu["aaecombo"].Cast<CheckBox>().CurrentValue)
            {
                E.Cast();
                Orbwalker.ResetAutoAttack();
                Player.IssueOrder(GameObjectOrder.AttackTo, AA_E_ResetTarget);
            }
        }

        #endregion E AA RESET

        #region Combo

        public static void ExecuteCombo()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var wtarget = TargetSelector.GetTarget(150, DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Physical);

            if (ComboMenu["aaecombo"].Cast<CheckBox>().CurrentValue)
            {
                if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                    if (Q.IsReady() && Q.IsLearned && qtarget.IsValidTarget(Q.Range))
                        if (HitChance.High >= HitChance.Low)
                        Q.TryToCast(qtarget, ComboMenu);

                if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                    if (W.IsReady() && W.IsLearned && W.IsOnCooldown && wtarget.IsValidTarget(W.Range = 150))
                        W.Cast();

                if (ComboMenu["R"].Cast<CheckBox>().CurrentValue &&
                    (Player.Instance.CountEnemiesInRange(600) >= ComboMenu["RCount"].Cast<Slider>().CurrentValue))
                    if (R.IsReady() && R.IsLearned && Q.IsOnCooldown && rtarget.IsValidTarget(R.Range))
                        R.Cast(rtarget);
            }
        }
        #endregion Combo
    }
}
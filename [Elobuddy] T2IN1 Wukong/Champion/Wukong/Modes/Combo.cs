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
        public static void InitializeExperimentalComboDelay()
        {
            Obj_AI_Base.OnPlayAnimation += ObjAiBaseOnOnPlayAnimation;
        }

        #region Experminental Q Combo Delay Code
        public static void ObjAiBaseOnOnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            if (args.Animation == "Spell1c")
            {
                Core.DelayAction(action: Orbwalker.ResetAutoAttack, delayTime: 300);
            }
        }
        #endregion Experminental Q Combo Delay Code

        #region GapCloser
        public static void wGapCloser()
        {
            var wtarget = TargetSelector.GetTarget(1300, DamageType.Physical);

            if (RIsActive())
                return;
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (W.IsReady() && W.IsLearned && wtarget.IsValidTarget(W.Range = 1300))
                    W.TryToCast(wtarget, ComboMenu);
        }
        #endregion GapCloser

        #region Current Normal Combo
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
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                        E.Cast(etarget);
                        Player.IssueOrder(GameObjectOrder.AutoAttack, etarget);
            }
            else
            {
                if (RIsActive())
                    return;
                if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                    if (E.IsReady() && E.IsLearned && etarget.IsValidTarget(E.Range))
                        E.Cast(etarget);
            }


            if (RIsActive())
                return;
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (Q.IsReady() && Q.IsLearned && qtarget.IsValidTarget(Q.Range))
                    Q.Cast();

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue &&
                (Player.Instance.CountEnemiesInRange(315) >= ComboMenu["RCount"].Cast<Slider>().CurrentValue))
                if (R.IsReady() && R.IsLearned && rtarget.IsValidTarget(R.Range))
                    R.Cast(rtarget);
        }
        #endregion Current Normal Combo
    }
}
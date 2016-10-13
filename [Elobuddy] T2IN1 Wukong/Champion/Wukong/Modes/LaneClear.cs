using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Wukong.Menus;
using static T2IN1_Wukong.SpellsManager;

namespace T2IN1_Wukong
{
    internal static class LaneClear
    {
        public static void Execute()
        {
            var MinionQ =
                ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(mq => mq.IsMinion && mq.IsValidTarget(Q.Range));
            if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemyMinionsInRange(650) >= 1) && Q.IsReady() && Q.IsLearned)
                    Q.TryToCast(MinionQ, LaneClearMenu);

            var MinionW =
                ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(mw => mw.IsMinion && mw.IsValidTarget(W.Range = 150));
            if (LaneClearMenu["W"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemyMinionsInRange(325) >= 3) && W.IsReady() && W.IsLearned)
                    W.TryToCast(MinionW, LaneClearMenu);

            var MinionE =
                ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(me => me.IsMinion && me.IsValidTarget(E.Range));
            if (LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemyMinionsInRange(650) >= 1) && E.IsReady() && E.IsLearned)
                    E.TryToCast(MinionE, LaneClearMenu);
        }
    }
}
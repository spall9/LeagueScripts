using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Wukong.Menus;
using static T2IN1_Wukong.Spells;
using static T2IN1_Wukong.SpellsManager;

namespace T2IN1_Wukong
{
    internal class JungleClear
    {
        public static void Execute()
        {
            var JungleMinionQ =
                ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(njmq => njmq.IsMonster && njmq.IsValidTarget(Q.Range));
            if (JungleClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (Q.IsReady() && Q.IsLearned)
                    Q.TryToCast(JungleMinionQ, JungleClearMenu);

            var JungleMinionE =
                ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(njme => njme.IsMonster && njme.IsValidTarget(E.Range));
            if (JungleClearMenu["E"].Cast<CheckBox>().CurrentValue)
                if (E.IsReady() && E.IsLearned)
                    E.TryToCast(JungleMinionE, JungleClearMenu);

            var JungleMinionW =
                ObjectManager.Get<Obj_AI_Minion>()
                    .FirstOrDefault(njmw => njmw.IsMonster && njmw.IsValidTarget(W.Range = 150));
            if (JungleClearMenu["W"].Cast<CheckBox>().CurrentValue)
                if (W.IsReady() && W.IsLearned)
                    W.TryToCast(JungleMinionW, JungleClearMenu);
        }

        public static void Init()
        {
            if (Smite != null)
                Game.OnTick += Game_OnTick;
        }

        public static void Game_OnTick(EventArgs agrs)
        {
            var Important = JungleClearMenu["AutoSmite"].Cast<CheckBox>().CurrentValue;
            var IMinionC =
                ObjectManager.Get<Obj_AI_Minion>()
                    .FirstOrDefault(
                        imc => imc.IsMonster && imc.IsValidTarget(Smite.Range) && Extensions.AutoSmiteIMinions(imc));
            var RedBuff =
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(rb => rb.IsMonster && rb.IsValidTarget(Smite.Range) && rb.Name.Contains("Red"))
                    .OrderBy(x => x.MaxHealth)
                    .LastOrDefault();
            var BlueBuff =
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(bb => bb.IsMonster && bb.IsValidTarget(Smite.Range) && bb.Name.Contains("Blue"))
                    .OrderBy(x => x.MaxHealth)
                    .LastOrDefault();

            if ((IMinionC != null) && IMinionC.IsValid && Important)
                if (IMinionC.Health <=
                    Player.Instance.GetSummonerSpellDamage(IMinionC, DamageLibrary.SummonerSpells.Smite))
                    Smite.Cast(IMinionC);

            if ((RedBuff != null) && RedBuff.IsValid && JungleClearMenu["JRed&Blue"].Cast<CheckBox>().CurrentValue)
                if (RedBuff.Health <=
                    Player.Instance.GetSummonerSpellDamage(IMinionC, DamageLibrary.SummonerSpells.Smite))
                    Smite.Cast(RedBuff);

            if ((BlueBuff != null) && BlueBuff.IsValid && JungleClearMenu["JRed&Blue"].Cast<CheckBox>().CurrentValue)
                if (BlueBuff.Health <=
                    Player.Instance.GetSummonerSpellDamage(IMinionC, DamageLibrary.SummonerSpells.Smite))
                    Smite.Cast(BlueBuff);
        }
    }
}
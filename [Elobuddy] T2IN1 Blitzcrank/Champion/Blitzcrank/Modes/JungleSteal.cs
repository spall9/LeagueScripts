using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Blitzcrank.Menus;
using static T2IN1_Blitzcrank.Spells;

namespace T2IN1_Blitzcrank
{
    internal class JungleSteal
    {
        public static void Execute()
        {
            if (Smite != null && JungleStealMenu["enablesteal"].Cast<CheckBox>().CurrentValue)
                Game.OnUpdate += Game_OnTick;
        }

        public static void Game_OnTick(EventArgs agrs)
        {
            var Important = JungleStealMenu["AutoSmite"].Cast<CheckBox>().CurrentValue;

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

            if ((RedBuff != null) && RedBuff.IsValid && JungleStealMenu["JRed&Blue"].Cast<CheckBox>().CurrentValue)
                if (RedBuff.Health <=
                    Player.Instance.GetSummonerSpellDamage(IMinionC, DamageLibrary.SummonerSpells.Smite))
                    Smite.Cast(RedBuff);

            if ((BlueBuff != null) && BlueBuff.IsValid && JungleStealMenu["JRed&Blue"].Cast<CheckBox>().CurrentValue)
                if (BlueBuff.Health <=
                    Player.Instance.GetSummonerSpellDamage(IMinionC, DamageLibrary.SummonerSpells.Smite))
                    Smite.Cast(BlueBuff);
        }
    }
}
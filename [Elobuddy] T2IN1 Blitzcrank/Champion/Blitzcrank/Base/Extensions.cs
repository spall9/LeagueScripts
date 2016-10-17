using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace T2IN1_Blitzcrank
{
    public static class Extensions
    {
        public static readonly AIHeroClient player = ObjectManager.Player;

        public static bool AutoSmiteIMinions(Obj_AI_Minion minion)
        {
            return minion.IsValidTarget()
                   && (minion.Name.ToLower().Contains("baron")
                       || minion.Name.ToLower().Contains("dragon")
                       || minion.Name.ToLower().Contains("herald"));
        }

        public static AIHeroClient GetKillableHero(this Spell.SpellBase spell)
        {
            return
                EntityManager.Heroes.Enemies.FirstOrDefault(
                    e =>
                        e.IsValidTarget(spell.Range) &&
                        (Prediction.Health.GetPrediction(e, spell.CastDelay) <= e.GetDamage(spell.Slot)) &&
                        !e.HasUndyingBuff());
        }

        public static Obj_AI_Minion GetLastHitMinion(this Spell.SpellBase spell)
        {
            return
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .FirstOrDefault(
                        m =>
                            m.IsValidTarget(spell.Range) &&
                            (Prediction.Health.GetPrediction(m, spell.CastDelay) <= m.GetDamage(spell.Slot)) &&
                            m.IsEnemy);
        }

        public static float GetTotalDamage(this Obj_AI_Base target)
        {
            var slots = new[] {SpellSlot.Q, SpellSlot.E, SpellSlot.R};
            var dmg = Player.Spells.Where(s => slots.Contains(s.Slot)).Sum(s => target.GetDamage(s.Slot));
            dmg += Orbwalker.CanAutoAttack ? Player.Instance.GetAutoAttackDamage(target) : 0f;

            return dmg;
        }
    }
}
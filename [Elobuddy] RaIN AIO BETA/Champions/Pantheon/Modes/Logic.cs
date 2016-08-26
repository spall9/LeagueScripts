using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace T2IN1_Pantheon
{
    public static class Logic
    {

        public static bool IsKillableTarget(AIHeroClient target, float range, SpellSlot key)
        {
            var x = target;
            if (x.IsValidTarget(range) && !x.HasBuffOfType(BuffType.Invulnerability) &&
                x.TotalShieldHealth() <= Player.Instance.GetSpellDamage(x, key))
            {
                return true;
            }

            return false;
        }

        public static bool IsKillableMinion(Obj_AI_Minion target, float range, SpellSlot key)
        {
            var x = target;
            if (x.IsValidTarget(range) && x.TotalShieldHealth() + 5 <= Player.Instance.GetSpellDamage(x, key))
            {
                return true;
            }

            return false;
        }

        public static List<AIHeroClient> CloseEnemies(float range = 1500, Vector3 from = default(Vector3))
        {
            return EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(range, false, from)).ToList();
        }

        public static List<AIHeroClient> CloseAllies(float range = 1500)
        {
            return EntityManager.Heroes.Allies.Where(a => a.IsValidTarget(range) && !a.IsMe).ToList();
        }

        public static List<Obj_AI_Minion> Minions(EntityManager.UnitTeam team, float range,
            Vector3 from = default(Vector3))
        {
            return EntityManager.MinionsAndMonsters.GetLaneMinions(team, from, range).ToList();
        }

        public static List<Obj_AI_Minion> Monsters(float range, Vector3 from = default(Vector3))
        {
            return EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(x => x.IsInRange(from, range)).ToList();
        }
    }
}
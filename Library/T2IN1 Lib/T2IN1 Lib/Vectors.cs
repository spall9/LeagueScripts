using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

// ReSharper disable CoVariantArrayConversion

namespace T2IN1_Lib
{
    public static class Vectors
    {
        public static bool IsSolid(this Vector3 pos)
        {
            return pos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Building) && pos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Wall);
        }

        public static Vector3 GetBestCircularFarmPosition(this Spell.Skillshot spell, int count = 3, int hitchance = 85)
        {
            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .Where(
                        m => m.IsValidTarget(spell.Range))
                    .ToArray();

            if (minions.Length == 0 && minions != null) return Vector3.Zero;

            var farmLocation = Prediction.Position.PredictCircularMissileAoe(minions, spell.Range, spell.Width,
                spell.CastDelay, spell.Speed).OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length).FirstOrDefault();

            if (farmLocation != null && farmLocation.HitChancePercent >= hitchance)
            {
                var predictedMinion = farmLocation.GetCollisionObjects<Obj_AI_Minion>();
                if (predictedMinion.Length >= count)
                {
                    return farmLocation.CastPosition;
                }
            }

            return Vector3.Zero;
        }

        public static Vector3 GetBestLinearFarmPosition(this Spell.Skillshot spell, int minMinionsToHit = 3)
        {
            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions().Where(m => m.IsValidTarget(spell.Range)).ToArray();

            var bestPos = EntityManager.MinionsAndMonsters.GetLineFarmLocation(minions, spell.Width,
                (int) spell.Range, Player.Instance.Position.To2D());

            if (minions.Length > 0 && bestPos.HitNumber >= minMinionsToHit)
            {
                return bestPos.CastPosition;
            }

            return Vector3.Zero;
        }

        public static Vector3 GetBestCircularCastPosition(this Spell.Skillshot spell, int count = 3, int hitchance = 75)
        {
            var heros =
                EntityManager.Heroes.Enemies.Where(
                    m => m.IsValidTarget(spell.Range))
                    .ToArray();

            if (heros.Length == 0 && heros != null) return Vector3.Zero;

            var castPos = Prediction.Position.PredictCircularMissileAoe(heros, spell.Range, spell.Width,
                spell.CastDelay, spell.Speed).OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length).FirstOrDefault();

            if (castPos != null && castPos.HitChancePercent >= hitchance)
            {
                var herosPredicted = castPos.GetCollisionObjects<AIHeroClient>();
                if (herosPredicted.Length >= count)
                {
                    return castPos.CastPosition;
                }
            }

            return Vector3.Zero;
        }

        public static BestCastPosition GetBestLinearCastPosition(this Spell.Skillshot spell, Vector2? sourcePosition = null)
        {
            var targets =
                EntityManager.Heroes.Enemies.Where(m => m.IsValidTarget(spell.Range)).ToArray();

            switch (targets.Length)
            {
                case 0:
                    return new BestCastPosition();
                case 1:
                    return new BestCastPosition {CastPosition = targets[0].ServerPosition, HitNumber = 1};
            }

            var posiblePositions = new List<Vector2>(targets.Select(o => o.ServerPosition.To2D()));
            foreach (var target in targets)
            {
                posiblePositions.AddRange(from t in targets
                    where t.NetworkId != target.NetworkId
                    select (t.ServerPosition.To2D() + target.ServerPosition.To2D())/2);
            }

            var startPos = sourcePosition ?? Player.Instance.ServerPosition.To2D();
            var minionCount = 0;
            var result = Vector2.Zero;

            foreach (var pos in posiblePositions.Where(o => o.IsInRange(startPos, spell.Range)))
            {
                var endPos = startPos + spell.Range*(pos - startPos).Normalized();
                var count = targets.Count(o => o.ServerPosition.To2D().Distance(startPos, endPos, true, true) <= spell.Width*spell.Width);

                if (count >= minionCount)
                {
                    result = endPos;
                    minionCount = count;
                }
            }

            return new BestCastPosition {CastPosition = result.To3DWorld(), HitNumber = minionCount};
        }

        public static Vector3 GetTargetDirection(this Obj_AI_Base target)
        {
            return target.Direction.To2D().Perpendicular().To3D();
        }

        public static Vector3 Back(this Obj_AI_Base target, int extendedRange = 100)
        {
            return target.Position.Extend(target.GetTargetDirection(), -extendedRange).To3D();
        }

        public static Vector3 Front(this Obj_AI_Base target, int extendedRange = 100)
        {
            return target.Position.Extend(target.GetTargetDirection(), extendedRange).To3D();
        }

        public static Vector3 Right(this Obj_AI_Base target, int extendedRange = 100)
        {
            return target.Position.Extend(target.GetTargetDirection(), extendedRange).RotateAroundPoint(Player.Instance.Position.To2D(), 90f).To3D();
        }

        public static Vector3 Left(this Obj_AI_Base target, int extendedRange = 100)
        {
            return target.Position.Extend(target.GetTargetDirection(), extendedRange).RotateAroundPoint(Player.Instance.Position.To2D(), 270f).To3D();
        }

        public struct BestCastPosition
        {
            public int HitNumber;
            public Vector3 CastPosition;
        }

        public static List<AIHeroClient> CloseAllies(float range = 1500)
        {
            return EntityManager.Heroes.Allies.Where(a => a.IsValidTarget(range) && !a.IsMe).ToList();
        }

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

        public static List<Obj_AI_Minion> Monsters(float range, Vector3 from = default(Vector3))
        {
            return EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(x => x.IsInRange(from, range)).ToList();
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

        public static List<Obj_AI_Minion> Minions(EntityManager.UnitTeam team, float range,
            Vector3 from = default(Vector3))
        {
            return EntityManager.MinionsAndMonsters.GetLaneMinions(team, from, range).ToList();
        }
    }
}
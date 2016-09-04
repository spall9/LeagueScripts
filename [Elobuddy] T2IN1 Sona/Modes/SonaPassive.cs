using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Sona.Base;

using static T2IN1_Sona.Base.SpellsManager;

namespace T2IN1_Sona.Modes
{
    internal class SonaPassive
    {
        public static void Passive()
        {
            var unit = TargetSelector.GetTarget(550, DamageType.Magical);
            if (Q.IsReady() && GetPassiveCount() == 2 && unit.IsValidTarget(Q.Range))
            {
                if (Q.IsReady())
                    Q.Cast();
                Player.IssueOrder(GameObjectOrder.AttackUnit, unit);
            }
        }

        public static int GetPassiveCount()
        {
            return (from buff in Sona.Buffs where buff.Name == "sonapassivecount" select buff.Count).FirstOrDefault();
        }
    }
}
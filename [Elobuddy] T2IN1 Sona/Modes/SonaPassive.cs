using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Sona.Base;

namespace T2IN1_Sona.Modes
{
    internal class SonaPassive
    {
        public static void Passive()
        {
            var unit = TargetSelector.GetTarget(550, DamageType.Magical);
            if (SpellsManager.Q.IsReady() && GetPassiveCount() == 2 && (unit.Distance(SpellsManager.Sona) <= 550))
            {
                if (SpellsManager.Q.IsReady()) SpellsManager.Q.Cast();
                Player.IssueOrder(GameObjectOrder.AttackUnit, unit);
            }
        }

        public static int GetPassiveCount()
        {
            return (from buff in SpellsManager.Sona.Buffs where buff.Name == "sonapassivecount" select buff.Count).FirstOrDefault();
        }
    }
}
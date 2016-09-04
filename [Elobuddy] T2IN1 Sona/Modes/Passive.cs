using EloBuddy;
using EloBuddy.SDK;
using static T2IN1_Sona.SpellsManager;

namespace T2IN1_Sona
{
    internal class SonaPassive
    {
        public static void Passive()
        {
            var unit = TargetSelector.GetTarget(550, DamageType.Magical);
            if (Q.IsReady() && (GetPassiveCount() == 2) && (unit.Distance(Sona) <= 550))
            {
                if (Q.IsReady()) Q.Cast();
                Player.IssueOrder(GameObjectOrder.AttackUnit, unit);
            }
        }

        public static int GetPassiveCount()
        {
            foreach (var buff in Sona.Buffs)
                if (buff.Name == "sonapassivecount") return buff.Count;
            return 0;
        }
    }
}
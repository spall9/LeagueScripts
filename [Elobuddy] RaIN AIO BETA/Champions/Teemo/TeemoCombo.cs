using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using static RaINAIO.TeemoSpellsManager;

namespace RaINAIO
{
    internal class TeemoCombo
    {
        public static void Combo()
        {
            if (Player.Instance.IsDead) return;
            if (Player.Instance.CountEnemiesInRange(750) == 0) return;

            var Qtarget = TargetSelector.GetTarget(TeemoSpellsManager.Q.Range, DamageType.Magical);
            var Rtarget = TargetSelector.GetTarget(TeemoSpellsManager.R.Range, DamageType.Magical);

            if (TeemoSpellsManager.Q.IsReady())
            {
                {
                    TeemoSpellsManager.Q.Cast(Qtarget);
                }
            }

            if (TeemoSpellsManager.W.IsReady())
            {
                var enemy = EntityManager.Heroes.Enemies.FirstOrDefault(x => !x.IsDead);

                {
                    TeemoSpellsManager.W.Cast();
                }
            }
        }
    }
}
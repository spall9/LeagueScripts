using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;
using static RaINAIO.ViktorSpellsManager;

namespace RaINAIO
{
    internal class ViktorCombo
    {
        public static void Combo()
        {
            if (Player.Instance.IsDead) return;
            if (Player.Instance.CountEnemiesInRange(750) == 0) return;

            var Qtarget = TargetSelector.GetTarget(ViktorSpellsManager.Q.Range, DamageType.Magical);
            var Wtarget = TargetSelector.GetTarget(ViktorSpellsManager.W.Range, DamageType.Magical);
            var Etarget = TargetSelector.GetTarget(ViktorSpellsManager.E.Range, DamageType.Magical);
            var Rtarget = TargetSelector.GetTarget(ViktorSpellsManager.R.Range, DamageType.Magical);

            if (ViktorSpellsManager.Q.IsReady())
            {
                {
                    ViktorSpellsManager.Q.Cast(Qtarget);
                }
            }

            if (ViktorSpellsManager.W.IsReady())
            {
                {
                    ViktorSpellsManager.W.Cast(Wtarget);
                }
            }

            if (ViktorSpellsManager.E.IsReady())
            {
                {
                    ViktorSpellsManager.E.Cast(Etarget);
                }
            }

            if (ViktorSpellsManager.R.IsReady())
            {
                {
                    ViktorSpellsManager.R.Cast(Rtarget);
                }
            }
        }
    }
}
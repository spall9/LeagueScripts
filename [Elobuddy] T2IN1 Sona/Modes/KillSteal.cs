////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;

namespace T2IN1_Sona.Modes
{
    internal class KillSteal
    {
        public static void Execute()
        {
            if (Menus.KillStealMenu["KS"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady())
                try
                {
                    foreach (
                        var qtarget in
                        EntityManager.Heroes.Enemies.Where(
                            hero => hero.IsValidTarget(SpellsManager.Q.Range) && !hero.IsDead && !hero.IsZombie))
                        if (SpellsManager.Sona.GetSpellDamage(qtarget, SpellSlot.Q) >= qtarget.Health)
                        {
                            {
                                if (SpellsManager.Q.IsInRange(qtarget) &&
                                    (SpellsManager.Q.IsReady() || (SonaPassive.GetPassiveCount() == 2)))
                                {
                                    SpellsManager.Q.Cast();
                                    Player.IssueOrder(GameObjectOrder.AttackUnit, qtarget);
                                }
                            }
                            {
                            }
                        }
                }
                catch
                {
                }
        }
    }
}
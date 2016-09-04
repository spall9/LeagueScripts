////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.SonaPassive;
using static T2IN1_Sona.SpellsManager;

namespace T2IN1_Sona
{
    internal class KillSteal
    {
        public static void Execute()
        {
            if (KillStealMenu["KS"].Cast<CheckBox>().CurrentValue && Q.IsReady())
                try
                {
                    foreach (
                        var qtarget in
                        EntityManager.Heroes.Enemies.Where(
                            hero => hero.IsValidTarget(Q.Range) && !hero.IsDead && !hero.IsZombie))
                        if (Sona.GetSpellDamage(qtarget, SpellSlot.Q) >= qtarget.Health)
                        {
                            {
                                if (Q.IsInRange(qtarget) && (Q.IsReady() || GetPassiveCount() == 2))
                                {
                                    Q.Cast();
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
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
    public static class LaneClear
    {
        public static void LaneClearLogic()
        {
            var qcheck = Menus.LaneClearMenu["LCQ"].Cast<CheckBox>().CurrentValue;
            var qready = SpellsManager.Q.IsReady();

            if (!qcheck || !qready) return;
            {
                var qenemy = (Obj_AI_Minion) Execute.GetEnemy(SpellsManager.Q.Range, GameObjectType.obj_AI_Minion);

                if (qenemy != null)
                    SpellsManager.Q.Cast();
                if (Orbwalker.CanAutoAttack)
                {
                    var enemy =
                        (Obj_AI_Minion)
                        Execute.GetEnemy(SpellsManager.Sona.GetAutoAttackRange(), GameObjectType.obj_AI_Minion);

                    if (enemy != null)
                        Orbwalker.ForcedTarget = enemy;
                }
            }
        }

        internal class Execute
        {
            public static AIHeroClient Sona
            {
                get { return ObjectManager.Player; }
            }

            public static Obj_AI_Base GetEnemy(float range, GameObjectType t)
            {
                switch (t)
                {
                    case GameObjectType.AIHeroClient:
                        return EntityManager.Heroes.Enemies.OrderBy(a => a.Health).FirstOrDefault(
                            a => (a.Distance(Player.Instance) < range) && !a.IsDead && !a.IsInvulnerable);
                    default:
                        return EntityManager.MinionsAndMonsters.EnemyMinions.OrderBy(a => a.Health).FirstOrDefault(
                            a => (a.Distance(Player.Instance) < range) && !a.IsDead && !a.IsInvulnerable);
                }
            }
        }
    }
}
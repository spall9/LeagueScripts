////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;

namespace T2IN1_Sona.Base
{
    internal class EventManager
    {
        public static void SmartE(Obj_AI_Base target)
        {
            try
            {
                if ((target.Path.Length == 0) || !target.IsMoving)
                    return;
                var nextEnemPath = target.Path[0].To2D();
                var dist = SpellsManager.Sona.Position.To2D().Distance(target.Position.To2D());
                var distToNext = nextEnemPath.Distance(SpellsManager.Sona.Position.To2D());
                if (distToNext <= dist)
                    return;
                var msDif = SpellsManager.Sona.MoveSpeed - target.MoveSpeed;
                if ((msDif <= 0) && !target.IsInAutoAttackRange(target))
                    SpellsManager.E.Cast();

                var reachIn = dist/msDif;
                if (reachIn > 4)
                    SpellsManager.E.Cast();
            }
            catch
            {
            }
        }
    }
}
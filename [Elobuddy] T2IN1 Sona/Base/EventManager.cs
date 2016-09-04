////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

using static T2IN1_Sona.Menus;
using static T2IN1_Sona.SpellsManager;

namespace T2IN1_Sona
{
    internal class EventManager
    {
        public static void SmartE(Obj_AI_Base target)
        {
            try
            {
                if (target.Path.Length == 0 || !target.IsMoving)
                    return;
                var nextEnemPath = target.Path[0].To2D();
                var dist = Sona.Position.To2D().Distance(target.Position.To2D());
                var distToNext = nextEnemPath.Distance(Sona.Position.To2D());
                if (distToNext <= dist)
                    return;
                var msDif = Sona.MoveSpeed - target.MoveSpeed;
                if (msDif <= 0 && !target.IsInAutoAttackRange(target))
                    E.Cast();

                var reachIn = dist / msDif;
                if (reachIn > 4)
                    E.Cast();
            }
            catch
            {
            }
        }
    }
}
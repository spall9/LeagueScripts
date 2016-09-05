////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Sona.Base.SpellsManager;
using static T2IN1_Sona.Base.Menus;

namespace T2IN1_Sona.Base
{
    internal class EventManager
    {
        public static void InitializeModes()
        {
            Interrupter.OnInterruptableSpell += Interruptererer;
            Game.OnWndProc += Game_OnWndProc;
        }

        public static void Game_OnWndProc(WndEventArgs args)
        {
            if (args.Msg != (uint) WindowMessages.LeftButtonDown)
                return;
            SelectedHero =
                EntityManager.Heroes.Enemies
                    .FindAll(hero => hero.IsValidTarget() && (hero.Distance(Game.CursorPos, true) < 39999))
                    .OrderBy(h => h.Distance(Game.CursorPos, true)).FirstOrDefault();
        }

        public static void Interruptererer(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            var intTarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            {
                if (R.IsReady() && sender.IsValidTarget(R.Range) &&
                    SupportMenu["IS"].Cast<CheckBox>().CurrentValue)
                    R.Cast(intTarget.ServerPosition);
            }
        }

        public static void SmartE(Obj_AI_Base target)
        {
            try
            {
                if ((target.Path.Length == 0) || !target.IsMoving)
                    return;


                var nextEnemPath = target.Path[0].To2D();
                var dist = Sona.Position.To2D().Distance(target.Position.To2D());
                var distToNext = nextEnemPath.Distance(Sona.Position.To2D());

                if (distToNext <= dist)
                    return;

                var msDif = Sona.MoveSpeed - target.MoveSpeed;
                if ((msDif <= 0) && !target.IsInAutoAttackRange(target))
                    E.Cast();

                var reachIn = dist/msDif;
                if (reachIn > 4)
                    E.Cast();
            }
            catch
            {
            }
        }
    }
}
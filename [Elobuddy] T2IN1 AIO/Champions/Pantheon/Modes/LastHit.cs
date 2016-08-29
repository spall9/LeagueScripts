using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Pantheon.Menus;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
// Credits to MarioGK for his Lib, Template and his Help, also thanks & Credits to Joker for Parts of his Lib //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using static T2IN1_Pantheon.SpellsManager;
using static T2IN1_Pantheon.Offensive;

namespace T2IN1_Pantheon
{
    internal class LastHit
    {
        public static void Execute()
        {
            //Cast Q
            if (LastHitMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (Q.IsReady())
                {
                    Q.TryToCast(Q.GetLastHitMinion(), LastHitMenu);
                }
            }

            //Cast E
            if (LastHitMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (E.IsReady())
                {
                    E.TryToCast(E.GetLastHitMinion(), LastHitMenu);

                    if (Player.Instance.Spellbook.IsChanneling)
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                    }
                    else
                    {
                        Orbwalker.DisableAttacking = false;
                        Orbwalker.DisableMovement = false;
                    }
                }
            }
        }
    }
}
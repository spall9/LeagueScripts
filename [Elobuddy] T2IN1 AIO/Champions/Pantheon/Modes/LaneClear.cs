////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

using T2IN1_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;
using static T2IN1_Pantheon.Offensive;

namespace T2IN1_Pantheon
{
    internal static class LaneClear
    {
        public static void Execute()
        {
            //Cast Q
            if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (Q.IsReady())
                {
                    Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
                }
            }

            //Cast E
            if (LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (E.IsReady())
                {
                    E.TryToCast(E.GetBestLinearFarmPosition(), LaneClearMenu);

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

            //Cast Hydra
            if (LaneClearMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
            {
                if (Hydra.IsReady())
                {
                    Hydra.Cast();
                }
            }

            //Cast Tiamat
            if (LaneClearMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
            {
                if (Tiamat.IsReady())
                {
                    Tiamat.Cast();
                }
            }
        }
    }
}
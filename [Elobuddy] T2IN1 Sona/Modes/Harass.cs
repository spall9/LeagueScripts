////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1;
using T2IN1_Lib;
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.SpellsManager;
using static T2IN1_Sona.Defensive;

namespace T2IN1_Sona
{
    internal static class Harass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(650, DamageType.Magical);
            Orbwalker.OrbwalkTo(MousePos);
            if (HarassMenu["QHarass"].Cast<CheckBox>().CurrentValue && Q.IsReady())
            {
                if (Q.IsInRange(target))
                {
                    Q.Cast();
                }
            }
        }
    }
}
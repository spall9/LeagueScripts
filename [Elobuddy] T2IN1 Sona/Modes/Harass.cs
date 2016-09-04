////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;

namespace T2IN1_Sona.Modes
{
    internal static class Harass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(650, DamageType.Magical);
            Orbwalker.OrbwalkTo(SpellsManager.MousePos);
            if (Menus.HarassMenu["QHarass"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady())
                if (SpellsManager.Q.IsInRange(target))
                    SpellsManager.Q.Cast();
        }
    }
}
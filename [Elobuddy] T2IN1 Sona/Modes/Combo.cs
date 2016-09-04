////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;
using T2IN1_Sona.Items;

namespace T2IN1_Sona.Modes
{
    internal static class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Magical);

            if ((target == null) || !target.IsValid())
                return;

            if (Orbwalker.IsAutoAttacking && Menus.ComboMenu["wAA"].Cast<CheckBox>().CurrentValue)
                return;

            if (Menus.ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.Q.IsReady() && (SpellsManager.Sona.CountEnemiesInRange(SpellsManager.Q.Range) >= 1))
                    SpellsManager.Q.Cast();
            if (Menus.ComboMenu["R"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady())
                {
                    var predR = SpellsManager.R.GetPrediction(target).CastPosition;
                    if (target.CountEnemiesInRange(SpellsManager.R.Width) >=
                        Menus.ComboMenu["rCount"].Cast<Slider>().CurrentValue)
                        SpellsManager.R.Cast(predR);
                }
            if (Menus.ComboMenu["UI"].Cast<CheckBox>().CurrentValue)
                if (Defensive.FrostQueen.IsOwned() && Defensive.FrostQueen.IsReady())
                    Defensive.FrostQueen.Cast();
        }
    }
}
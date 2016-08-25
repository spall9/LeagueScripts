using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal static class TeemoCombo
    {
        public static void ComboSpells()
        {
            //Declare Q Spell Values
            Q = new Spell.Targeted(spellSlot: SpellSlot.Q, spellRange: 580);

            //Triggers with every Core Tick
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            //Returns true if Combo Mode is Active in the Orbwalker 
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Combo))
                Combo();
        }

        public static void Combo()
        {
            //Returns TargetSelector Target from the Range set
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            //Return true of Target doesnt exist or null
            if (qtarget == null)
            {
                return;
            }

            //Returns true if the Checkbox Q is enabled
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                //Returns true if Target is valid in Q Range
                if (qtarget.IsValidTarget(Q.Range) && Q.IsReady())
                {
                    //Cast already applies Prediction so its not needed to use Qpred.CastPostion
                    Q.Cast(qtarget);
                }
            }
        }
    }
}
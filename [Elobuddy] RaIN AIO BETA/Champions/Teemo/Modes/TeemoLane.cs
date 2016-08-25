using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

using static RaINAIO.TeemoSpellsManager;

namespace RaINAIO
{
    internal static class TeemoLane
    {
        public static void ComboSpells()
        {
            //Declare Q Spell Values
            Q = new Spell.Targeted(spellSlot: SpellSlot.Q, spellRange: 580);

            //Declare R Spell Values
            R = new Spell.Skillshot(spellSlot: SpellSlot.R, skillShotType: SkillShotType.Circular, spellRange: 300);

            //Triggers with every Core Tick
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            //Returns true if Combo Mode is Active in the Orbwalker 
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Combo))
                LaneClear();
        }

        public static void LaneClear()
        {
            
        }
    }
}
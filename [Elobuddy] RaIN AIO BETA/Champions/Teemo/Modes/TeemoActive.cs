using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal class Active
    {
        public static void TeemoActive()
        {
            //Declare Q Spell Values
            Q = new Spell.Targeted(spellSlot: SpellSlot.Q, spellRange: 580);

            //Declare R Spell Values
            W = new Spell.Active(spellSlot: SpellSlot.W);

            //Declare R Spell Values
            E = new Spell.Active(SpellSlot.E, spellRange: 680);

            //Declare R Spell Values
            R = new Spell.Skillshot(spellSlot: SpellSlot.R, spellRange: 400, skillShotType: SkillShotType.Circular);
        }
    }
}
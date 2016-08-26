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
            Q = new Spell.Targeted(spellSlot: SpellSlot.Q, spellRange: 680);
            W = new Spell.Active(spellSlot: SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, spellRange: 680);
            R = new Spell.Skillshot(spellSlot: SpellSlot.R, spellRange: 400, skillShotType: SkillShotType.Cone, castDelay: 500, spellSpeed: 1000, spellWidth: 120);
        }
    }
}
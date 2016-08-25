using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

using static T2IN1.TeemoAutoLevel;

namespace T2IN1
{
    public static class TeemoSpells
    {
        /*
        Targeted spells are like Katarina`s Q
        Active spells are like Katarina`s W
        Skillshots are like Ezreal`s Q
        Circular Skillshots are like Lux`s E and Tristana`s W
        Cone Skillshots are like Annie`s W and ChoGath`s W
        */

        public static Spell.Targeted Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Skillshot R;

        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {

            SpellList.Add(Q);
            SpellList.Add(W);
            SpellList.Add(E);
            SpellList.Add(R);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        //It will return the damage but you need to set them before getting the damage
        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            const DamageType damageType = DamageType.Magical;
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;

            //You can get the damage information easily on http://de.leagueoflegends.wikia.com/wiki/League_of_Legends_Wiki

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                    {
                        //Information Q Damage
                        dmg += new float[] { 80, 125, 170, 215, 260 }[sLevel] + 0.8f * AP;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        //Information W Damage
                        dmg += new float[] { 0, 0, 0, 0, 0 }[sLevel] + 0.0f * AP;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        //Information E Damage
                        dmg += new float[] { 24, 48, 72, 96, 120 }[sLevel] + 0.4f * AP;
                        dmg += new float[] { 6, 12, 18, 24, 30 }[sLevel] + 0.1f * AP;
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        //Information R Damage
                        dmg += new float[] { 200, 325, 450 }[sLevel] + 0.5f * AP;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }
    }
}

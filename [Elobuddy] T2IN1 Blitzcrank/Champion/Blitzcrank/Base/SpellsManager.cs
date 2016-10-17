using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using static T2IN1_Blitzcrank.AutoLevel;

namespace T2IN1_Blitzcrank
{
    public static class SpellsManager
    {
        /*
        Targeted spells are like Katarina`s Q
        Active spells are like Katarina`s W
        Skillshots are like Ezreal`s Q
        Circular Skillshots are like Lux`s E and Tristana`s W
        Cone Skillshots are like Annie`s W and ChoGath`s W
        */

        public static Spell.Skillshot Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Active R;
        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 925, SkillShotType.Linear, 250, 1800, 70);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, 300);
            R = new Spell.Active(SpellSlot.R, 600);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        #region Damages

        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Mixed;
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;

            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                        dmg += new float[] {80, 135, 190, 245, 300}[sLevel] + 1f*AP;
                    break;
                case SpellSlot.W:
                    if (E.IsReady())
                        dmg += new float[] {0, 0, 0, 0, 0}[sLevel] + 0f*AP +
                               Player.Instance.GetAutoAttackDamage(etarget);
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                        dmg += new float[] {0, 0, 0, 0, 0}[sLevel] + 0f*AD;
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                        dmg += new float[] {250, 375, 500}[sLevel] + 1f*AP;
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }

        #endregion Damages
    }
}
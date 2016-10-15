using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using static T2IN1_Wukong.AutoLevel;

namespace T2IN1_Wukong
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

        public static Spell.Active Q;
        public static Spell.Active W;
        public static Spell.Targeted E;
        public static Spell.Skillshot R;
        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {
            Q = new Spell.Active(SpellSlot.Q, 315);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Targeted(SpellSlot.E, 650);
            R = new Spell.Skillshot(SpellSlot.R, 315, SkillShotType.Cone);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        #region Damages

        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Mixed;
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;

            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                        dmg += new float[] {30, 60, 90, 120, 150}[sLevel] + 0.1f*AD +
                               Player.Instance.GetAutoAttackDamage(qtarget);
                    break;
                case SpellSlot.W:
                    if (E.IsReady())
                        dmg += new float[] {70, 115, 160, 205, 250}[sLevel] + 0.6f*AP;
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                        dmg += new float[] {60, 105, 150, 195, 240}[sLevel] + 0.8f*AD;
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                        dmg += new float[] {20, 110, 200}[sLevel] + 1.1f*AD;
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }

        #endregion Damages
    }
}
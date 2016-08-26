using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Mario_s_Lib;
using SharpDX.Windows;
using static T2IN1_Pantheon.Menus;

namespace T2IN1_Pantheon
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

        //Remenber of putting the correct type of the spell here
        public static Spell.Targeted Q;
        public static Spell.Targeted W;
        public static Spell.Skillshot E;
        public static Spell.Skillshot R;

        public static void InitializeSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 600);
            W = new Spell.Targeted(SpellSlot.W, 600);
            E = new Spell.Skillshot(SpellSlot.E, 600, SkillShotType.Cone, 250, 800, (int)(35 * Math.PI / 180));
            R = new Spell.Skillshot(SpellSlot.R, 5500, SkillShotType.Cone, 0, 0, 800);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        #region Damages

        /// It will return the damage but you need to set them before getting the damage
        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Mixed;
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;

            //You can get the damage information easily on Wiki

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                    {
                        dmg += new float[] { 65, 105, 145, 185, 225 }[sLevel] + 1.4f * AD;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        dmg += new float[] { 50, 75, 100, 125, 150 }[sLevel] + 1f * AP;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        dmg += new float[] { 80, 130, 180, 230, 280 }[sLevel] + 1f * AD; 
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        dmg += new float[] { 400, 700, 1000 }[sLevel] + 1f * AP;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }

        #endregion Damages

        /// This event is triggered when a unit levels up
        private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (MiscMenu.GetCheckBoxValue("activateAutoLVL") && sender.IsMe)
            {
                var delay = MiscMenu.GetSliderValue("delaySlider");
                Core.DelayAction(LevelUPSpells, delay);

            }
        }

        /// It will level up the spell using the values of the comboboxes on the menu as a priority
        private static void LevelUPSpells()
        {
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
            {
                Player.Instance.Spellbook.LevelSpell(SpellSlot.R);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(GetSlotFromComboBox(MiscMenu.GetComboBoxValue("firstFocus"))))
            {
                Player.Instance.Spellbook.LevelSpell(GetSlotFromComboBox(MiscMenu.GetComboBoxValue("firstFocus")));
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(GetSlotFromComboBox(MiscMenu.GetComboBoxValue("secondFocus"))))
            {
                Player.Instance.Spellbook.LevelSpell(GetSlotFromComboBox(MiscMenu.GetComboBoxValue("secondFocus")));
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(GetSlotFromComboBox(MiscMenu.GetComboBoxValue("thirdFocus"))))
            {
                Player.Instance.Spellbook.LevelSpell(GetSlotFromComboBox(MiscMenu.GetComboBoxValue("thirdFocus")));
            }
        }

        /// It will transform the value of the combobox into a SpellSlot
        private static SpellSlot GetSlotFromComboBox(this int value)
        {
            switch (value)
            {
                case 0:
                    return SpellSlot.Q;
                case 1:
                    return SpellSlot.W;
                case 2:
                    return SpellSlot.E;
            }
            Chat.Print("Failed getting slot");
            return SpellSlot.Unknown;
        }
    }
}
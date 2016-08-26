using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Mario_s_Lib;
using SharpDX.Windows;
using static T2IN1_Teemo.Menus;

namespace T2IN1_Teemo
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
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Skillshot R;

        public static void InitializeSpells()
        {
            Q = new Spell.Targeted(spellSlot: SpellSlot.Q, spellRange: 680);
            W = new Spell.Active(spellSlot: SpellSlot.W);
            E = new Spell.Active(SpellSlot.E, spellRange: 680);
            R = new Spell.Skillshot(spellSlot: SpellSlot.R, spellRange: 400, skillShotType: SkillShotType.Cone, castDelay: 500, spellSpeed: 1000, spellWidth: 120);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        // No Idea what i just did here :P
        public static float rlevel(SpellSlot slot)
        {
            var rLevel = Player.GetSpell(SpellSlot.R).Level - 1;
            var range = 1f;

            switch (slot)
            {
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        range += new float[] {400, 650, 900}[rLevel];
                    }
                    break;

            }
            return Player.Instance.Level;
        }

        #region Damages

        /// It will return the damage but you need to set them before getting the damage
        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Magical;
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
                        dmg += new float[] { 80, 125, 170, 215, 260 }[sLevel] + 0.8f * AP;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        dmg += new float[] { 0, 0, 0, 0, 0 }[sLevel];
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        dmg += new float[] { 24, 48, 72, 96, 120 }[sLevel] + 0.4f * AP;
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        dmg += new float[] { 200, 325, 450 }[sLevel] + 0.5f * AP;
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
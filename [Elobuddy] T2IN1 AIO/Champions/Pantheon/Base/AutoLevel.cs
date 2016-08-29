////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
// Credits to MarioGK for his Lib, Template and his Help, also thanks & Credits to Joker for Parts of his Lib //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Lib;

using static T2IN1_Pantheon.Menus;

namespace T2IN1_Pantheon
{
    public static class AutoLevel
    {
        //This event is triggered when a unit levels up
        public static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (MiscMenu.GetCheckBoxValue("activateAutoLVL") && sender.IsMe)
            {
                var delay = MiscMenu.GetSliderValue("delaySlider");
                Core.DelayAction(LevelUPSpells, delay);

            }
        }
        
        //It will level up the spell using the values of the comboboxes on the menu as a priority
        private static void LevelUPSpells()
        {
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
            {
                Player.Instance.Spellbook.LevelSpell(SpellSlot.R);
            }

            var firstFocusSlot = GetSlotFromComboBox(MiscMenu.GetComboBoxValue("firstFocus"));
            var secondFocusSlot = GetSlotFromComboBox(MiscMenu.GetComboBoxValue("secondFocus"));
            var thirdFocusSlot = GetSlotFromComboBox(MiscMenu.GetComboBoxValue("thirdFocus"));

            var secondSpell = Player.GetSpell(secondFocusSlot);
            var thirdSpell = Player.GetSpell(thirdFocusSlot);

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(firstFocusSlot))
            {
                if (!secondSpell.IsLearned)
                {
                    Player.Instance.Spellbook.LevelSpell(secondFocusSlot);
                }
                if (!thirdSpell.IsLearned)
                {
                    Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
                }
                Player.Instance.Spellbook.LevelSpell(firstFocusSlot);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(secondFocusSlot))
            {
                if (!thirdSpell.IsLearned)
                {
                    Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
                }
                Player.Instance.Spellbook.LevelSpell(firstFocusSlot);
                Player.Instance.Spellbook.LevelSpell(secondFocusSlot);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(thirdFocusSlot))
            {
                Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
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
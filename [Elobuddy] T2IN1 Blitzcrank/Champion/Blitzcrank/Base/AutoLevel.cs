using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Lib;
using static T2IN1_Wukong.Menus;

namespace T2IN1_Wukong
{
    public static class AutoLevel
    {
        public static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (MiscMenu.GetCheckBoxValue("activateAutoLVL") && sender.IsMe)
            {
                var delay = MiscMenu.GetSliderValue("delaySlider");
                Core.DelayAction(LevelUPSpells, delay);
            }
        }

        private static void LevelUPSpells()
        {
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
                Player.Instance.Spellbook.LevelSpell(SpellSlot.R);

            var firstFocusSlot = GetSlotFromComboBox(MiscMenu.GetComboBoxValue("firstFocus"));
            var secondFocusSlot = GetSlotFromComboBox(MiscMenu.GetComboBoxValue("secondFocus"));
            var thirdFocusSlot = GetSlotFromComboBox(MiscMenu.GetComboBoxValue("thirdFocus"));

            var secondSpell = Player.GetSpell(secondFocusSlot);
            var thirdSpell = Player.GetSpell(thirdFocusSlot);

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(firstFocusSlot))
            {
                if (!secondSpell.IsLearned)
                    Player.Instance.Spellbook.LevelSpell(secondFocusSlot);
                if (!thirdSpell.IsLearned)
                    Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
                Player.Instance.Spellbook.LevelSpell(firstFocusSlot);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(secondFocusSlot))
            {
                if (!thirdSpell.IsLearned)
                    Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
                Player.Instance.Spellbook.LevelSpell(firstFocusSlot);
                Player.Instance.Spellbook.LevelSpell(secondFocusSlot);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(thirdFocusSlot))
                Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
        }

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
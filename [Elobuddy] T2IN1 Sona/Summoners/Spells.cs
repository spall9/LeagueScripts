////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace T2IN1_Sona
{
    public static class Spells
    {
        public static Spell.Active Barrier = new Spell.Active(ReturnSlot("summonerbarrier"));
        public static Spell.Active Heal = new Spell.Active(ReturnSlot("summonerheal"), 850);
        public static Spell.Targeted Ignite = new Spell.Targeted(ReturnSlot("summonerdot"), 600);
        public static Spell.Targeted Smite = new Spell.Targeted(ReturnSlot(SmiteNames), 500);
        public static Spell.Active Cleanse = new Spell.Active(ReturnSlot("summonerboost"));
        public static Spell.Targeted Exhaust = new Spell.Targeted(ReturnSlot("summonerexhaust"), 650);

        private static string[] SmiteNames => new[]
        {
            "s5_summonersmiteplayerganker", "s5_summonersmiteduel",
            "s5_summonersmitequick", "itemsmiteaoe", "summonersmite"
        };

        private static SpellSlot ReturnSlot(string Name)
        {
            return Player.Instance.GetSpellSlotFromName(Name);
        }

        private static SpellSlot ReturnSlot(string[] Name)
        {
            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.ToLower()))
                return SpellSlot.Summoner1;

            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.ToLower()))
                return SpellSlot.Summoner2;

            return SpellSlot.Unknown;
        }
    }
}
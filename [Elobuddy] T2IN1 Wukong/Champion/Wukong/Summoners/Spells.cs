using EloBuddy;
using EloBuddy.SDK;
using System.Linq;

namespace T2IN1_Wukong
{
    public static class Spells
    {
        public static Spell.Targeted Ignite = new Spell.Targeted(ReturnSlot("summonerdot"), 600);
        public static Spell.Targeted Smite = new Spell.Targeted(ReturnSlot(SmiteNames), 500);

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
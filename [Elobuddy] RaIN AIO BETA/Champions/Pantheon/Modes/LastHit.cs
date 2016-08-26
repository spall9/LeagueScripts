using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;

namespace T2IN1_Pantheon
{
    internal class LastHit
    {
        public static void Execute()
        {
            E.TryToCast(E.GetKillableHero(), LastHitMenu);
        }
    }
}
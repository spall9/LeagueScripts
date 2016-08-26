using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;

using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;

namespace T2IN1_Teemo
{
    internal class LastHit
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetKillableHero(), LasthitMenu);
        }
    }
}
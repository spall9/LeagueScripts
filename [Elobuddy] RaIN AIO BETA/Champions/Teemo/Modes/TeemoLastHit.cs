using Mario_s_Lib;
using Mario_s_Template;
using static T2IN1.TeemoMenu;
using static T2IN1.TeemoSpells;

namespace T2IN1
{
    internal class LastHit
    {

        public static void Execute()
        {
            Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
        }
    }
}
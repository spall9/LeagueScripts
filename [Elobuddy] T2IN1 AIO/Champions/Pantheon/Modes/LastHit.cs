using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;
using static T2IN1_Pantheon.Offensive;

namespace T2IN1_Pantheon
{
    internal class LastHit
    {
        public static void Execute()
        {
            if (LastHitMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (Q.IsReady())
                {
                    Q.TryToCast(Q.GetLastHitMinion(), LastHitMenu);
                }
            }

            if (LastHitMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (E.IsReady())
                {
                    E.TryToCast(E.GetLastHitMinion(), LastHitMenu);
                    Orbwalker.DisableAttacking = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
                    Orbwalker.DisableMovement = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
                }
            }
        }
    }
}
﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

using T2IN1_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;
using static T2IN1_Pantheon.Offensive;

namespace T2IN1_Pantheon
{
    internal static class LaneClear
    {
        public static void Execute()
        {
            if (LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (Q.IsReady())
                {
                    Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
                }
            }

            if (LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (E.IsReady())
                {
                    E.TryToCast(E.GetBestCircularCastPosition(), LaneClearMenu);
                    Orbwalker.DisableAttacking = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
                    Orbwalker.DisableMovement = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
                }
            }

            if (LaneClearMenu["Hydra"].Cast<CheckBox>().CurrentValue)
            {
                if (Hydra.IsReady())
                {
                    Hydra.Cast();
                }
            }

            if (LaneClearMenu["Tiamat"].Cast<CheckBox>().CurrentValue)
            {
                if (Tiamat.IsReady())
                {
                    Tiamat.Cast();
                }
            }
        }
    }
}
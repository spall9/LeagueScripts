using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace T2IN1_Pantheon
 {
     public static class Active
     {
         public static void Execute()
         {
            Orbwalker.DisableAttacking = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
            Orbwalker.DisableMovement = Player.Instance.Spellbook.IsChanneling || Player.Instance.Spellbook.IsChanneling;
        }
     }
 } 
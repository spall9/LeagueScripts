using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

using static RaINAIO.TeemoMenu;
using static RaINAIO.TeemoSpellsManager;

namespace RaINAIO
{
    internal class TeemoFlee
    {
        public static void FleeSpells()
        {
            //Declare W Spell Values
            W = new Spell.Active(SpellSlot.W);

            //Triggers with every Core Tick
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            //Returns true if Flee Mode is Active in the Orbwalker 
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Flee))
                Flee();
        }

        public static void Flee()
        {
            //Returns true if the Checkbox W is enabled
            if (FleeMenu["W"].Cast<CheckBox>().CurrentValue)
            {
                if (W.IsReady())
                W.Cast();
            }
        }
    }
}
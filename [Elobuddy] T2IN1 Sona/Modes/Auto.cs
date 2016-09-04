using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.SpellsManager;
using static T2IN1_Sona.SonaPassive;

namespace T2IN1_Sona
{
    internal class Auto
    {
        public static void AutoW()
        {
            var healAllies = MiscMenu["HPLA"].Cast<CheckBox>().CurrentValue;
            var healHealthPercent = MiscMenu["wS"].Cast<Slider>().CurrentValue;

            if (healAllies)
            {
                var ally =
                    EntityManager.Heroes.Allies
                        .FirstOrDefault(x => x.IsValidTarget(W.Range) && x.HealthPercent < healHealthPercent);

                if (ally != null)
                    W.Cast();
            }
        }

        public static void Interruptererer(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            var intTarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            {
                if (R.IsReady() && sender.IsValidTarget(R.Range) &&
                    MiscMenu["IS"].Cast<CheckBox>().CurrentValue)
                    R.Cast(intTarget.ServerPosition);
            }
        }
    }
}
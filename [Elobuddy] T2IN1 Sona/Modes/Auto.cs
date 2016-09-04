using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Sona.Base;

using static T2IN1_Sona.Base.SpellsManager;

namespace T2IN1_Sona.Modes
{
    internal class Auto
    {
        public static void AutoW()
        {
            var healAllies = Menus.SupportMenu["HPLA"].Cast<CheckBox>().CurrentValue;
            var healHealthPercent = Menus.SupportMenu["wS"].Cast<Slider>().CurrentValue;

            if (Sona.IsRecalling())
                return;

            if (healAllies)
            {
                var ally =
                EntityManager.Heroes.Allies
                .FirstOrDefault(
                    x => x.IsValidTarget(W.Range) && (x.HealthPercent < healHealthPercent));

                if (ally != null)
                    W.Cast();
            }
        }

        public static void Interruptererer(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            var intTarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            {
                if (R.IsReady() && sender.IsValidTarget(R.Range) &&
                    Menus.SupportMenu["IS"].Cast<CheckBox>().CurrentValue)
                    R.Cast(intTarget.ServerPosition);
            }
        }
    }
}
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Pantheon.Menus;
using static T2IN1_Pantheon.SpellsManager;
using static T2IN1_Pantheon.Offensive;

namespace T2IN1_Pantheon
{
    internal static class Combo
    {
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);

            if (qtarget == null || qtarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
            {
                if (qtarget.IsValidTarget(Q.Range) && Q.IsReady())
                {
                    Q.TryToCast(qtarget, ComboMenu);
                }
            }

            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);

            if (etarget == null || etarget.IsInvulnerable)
            {
                return;
            }

            
            if (ComboMenu["ECancel"].Cast<CheckBox>().CurrentValue)
            {
                if (etarget.IsValidTarget(E.Range) && E.IsReady())
                {
                    E.TryToCast(etarget, ComboMenu);
                }
            }

            
            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (etarget.IsValidTarget(E.Range) && E.IsReady())
                {
                    E.TryToCast(etarget, ComboMenu);
                }
            }

            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);

            if (wtarget == null || wtarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
            {
                if (wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.TryToCast(wtarget, ComboMenu);
                    HydraTitanic.Cast();
                }
            }

            //Cast Hydra
            var hydratarget = TargetSelector.GetTarget(Hydra.Range, DamageType.True);

            if (hydratarget == null || hydratarget.IsInvulnerable)
            {
                return;
            }
            
            if (ComboMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
            {
                if (hydratarget.IsValidTarget(Hydra.Range) && Hydra.IsReady())
                {
                    Hydra.Cast();
                }
            }
            //Cast Tiamat
            var tiamattarget = TargetSelector.GetTarget(Tiamat.Range, DamageType.True);

            if (tiamattarget == null || tiamattarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
            {
                if (tiamattarget.IsValidTarget(Tiamat.Range) && Tiamat.IsReady())
                {
                    Tiamat.Cast();
                }
            }
            //Cast TitanicHydra
            var titanichydratarget = TargetSelector.GetTarget(HydraTitanic.Range, DamageType.True);

            if (titanichydratarget == null || titanichydratarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["TitanicHydra"].Cast<CheckBox>().CurrentValue)
            {
                if (titanichydratarget.IsValidTarget(HydraTitanic.Range) && HydraTitanic.IsReady())
                {
                    HydraTitanic.Cast();
                }
            }
            //Cast Blade of the Ruined King
            var botrktarget = TargetSelector.GetTarget(Botrk.Range, DamageType.Physical);

            if (botrktarget == null || botrktarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Botrk"].Cast<CheckBox>().CurrentValue)
            {
                if (botrktarget.IsValidTarget(Botrk.Range) && Botrk.IsReady())
                {
                    Botrk.Cast(botrktarget);
                }
            }
            //Cast Hextech Gunblade
            var gunbladetarget = TargetSelector.GetTarget(Gunblade.Range, DamageType.Magical);

            if (gunbladetarget == null || gunbladetarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Gunblade"].Cast<CheckBox>().CurrentValue)
            {
                if (gunbladetarget.IsValidTarget(Gunblade.Range) && Gunblade.IsReady())
                {
                    Gunblade.Cast(gunbladetarget);
                }
            }
            //Cast Protobelt
            var protobelttarget = TargetSelector.GetTarget(Protobelt.Range, DamageType.Magical);

            if (protobelttarget == null || protobelttarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Protobelt"].Cast<CheckBox>().CurrentValue)
            {
                if (protobelttarget.IsValidTarget(Protobelt.Range) && Protobelt.IsReady())
                {
                    Protobelt.Cast(protobelttarget.Direction);
                }
            }
            //Cast GLP
            var glptarget = TargetSelector.GetTarget(GLP.Range, DamageType.Magical);

            if (glptarget == null || glptarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["GLP"].Cast<CheckBox>().CurrentValue)
            {
                if (glptarget.IsValidTarget(GLP.Range) && GLP.IsReady())
                {
                    GLP.Cast(glptarget);
                }
            }
            //Cast Bilgewater Cutlass
            var cutlasstarget = TargetSelector.GetTarget(Cutlass.Range, DamageType.Magical);

            if (cutlasstarget == null || cutlasstarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["Cutlass"].Cast<CheckBox>().CurrentValue)
            {
                if (cutlasstarget.IsValidTarget(Cutlass.Range) && Cutlass.IsReady())
                {
                    Cutlass.Cast(cutlasstarget);
                }
            }
        }
    }
}
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;

using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;
using static T2IN1_Teemo.Offensive;

namespace T2IN1_Teemo
{
    internal static class Combo
    {
        public static void Execute1()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

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
                    Protobelt.Cast(protobelttarget);
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
        }

        public static void Execute2()
        {
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if (rtarget == null || rtarget.IsInvulnerable)
            {
                return;
            }

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (rtarget.IsValidTarget(R.Range) && R.IsReady())
                {
                    R.TryToCast(rtarget, ComboMenu);
                    
                }
            }
        }
    }
}
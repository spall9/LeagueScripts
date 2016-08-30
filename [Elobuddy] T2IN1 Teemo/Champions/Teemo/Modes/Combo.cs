////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static T2IN1_Teemo.Menus;
using static T2IN1_Teemo.SpellsManager;
using static T2IN1_Teemo.Offensive;
using static T2IN1_Teemo.Spells;

namespace T2IN1_Teemo
{
    internal static class Combo
    {
        public static void Execute1()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(Q.Range) && Q.IsReady())
                    Q.TryToCast(qtarget, ComboMenu);
        }

        public static void ExecuteR()
        {
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;
            //Cast R
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
                if (rtarget.IsValidTarget(R.Range) && R.IsReady())
                    R.TryToCast(rtarget, ComboMenu);
        }

        public static void ExecuteItems()
        {
            //Item Target's
            var hydratarget = TargetSelector.GetTarget(Hydra.Range, DamageType.True);
            var tiamattarget = TargetSelector.GetTarget(Tiamat.Range, DamageType.True);
            var titanichydratarget = TargetSelector.GetTarget(HydraTitanic.Range, DamageType.True);
            var botrktarget = TargetSelector.GetTarget(Botrk.Range, DamageType.Physical);
            var gunbladetarget = TargetSelector.GetTarget(Gunblade.Range, DamageType.Magical);
            var protobelttarget = TargetSelector.GetTarget(Protobelt.Range, DamageType.Magical);
            var glptarget = TargetSelector.GetTarget(GLP.Range, DamageType.Magical);
            var cutlasstarget = TargetSelector.GetTarget(Cutlass.Range, DamageType.Magical);


            if ((hydratarget == null) || hydratarget.IsInvulnerable)
                return;
            //Cast Hydra
            if (ComboMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
                if (hydratarget.IsValidTarget(Hydra.Range) && Hydra.IsReady())
                    Hydra.Cast();

            if ((tiamattarget == null) || tiamattarget.IsInvulnerable)
                return;
            //Cast Tiamat
            if (ComboMenu["HydraTiamat"].Cast<CheckBox>().CurrentValue)
                if (tiamattarget.IsValidTarget(Tiamat.Range) && Tiamat.IsReady())
                    Tiamat.Cast();

            if ((titanichydratarget == null) || titanichydratarget.IsInvulnerable)
                return;
            //Cast TitanicHydra
            if (ComboMenu["TitanicHydra"].Cast<CheckBox>().CurrentValue)
                if (titanichydratarget.IsValidTarget(HydraTitanic.Range) && HydraTitanic.IsReady())
                    HydraTitanic.Cast();

            if ((botrktarget == null) || botrktarget.IsInvulnerable)
                return;
            //Cast Blade of the Ruined King
            if (ComboMenu["Botrk"].Cast<CheckBox>().CurrentValue)
                if (botrktarget.IsValidTarget(Botrk.Range) && Botrk.IsReady())
                    Botrk.Cast(botrktarget);

            if ((gunbladetarget == null) || gunbladetarget.IsInvulnerable)
                return;
            //Cast Hextech Gunblade
            if (ComboMenu["Gunblade"].Cast<CheckBox>().CurrentValue)
                if (gunbladetarget.IsValidTarget(Gunblade.Range) && Gunblade.IsReady())
                    Gunblade.Cast(gunbladetarget);

            if ((protobelttarget == null) || protobelttarget.IsInvulnerable)
                return;
            //Cast Protobelt
            if (ComboMenu["Protobelt"].Cast<CheckBox>().CurrentValue)
                if (protobelttarget.IsValidTarget(Protobelt.Range) && Protobelt.IsReady())
                    Protobelt.Cast(protobelttarget.Position);

            if ((glptarget == null) || glptarget.IsInvulnerable)
                return;
            //Cast GLP
            if (ComboMenu["GLP"].Cast<CheckBox>().CurrentValue)
                if (glptarget.IsValidTarget(GLP.Range) && GLP.IsReady())
                    GLP.Cast(glptarget);

            if ((cutlasstarget == null) || cutlasstarget.IsInvulnerable)
                return;
            //Cast Bilgewater Cutlass
            if (ComboMenu["Cutlass"].Cast<CheckBox>().CurrentValue)
                if (cutlasstarget.IsValidTarget(Cutlass.Range) && Cutlass.IsReady())
                    Cutlass.Cast(cutlasstarget);

            //Summoners Target
            var Summ1 = TargetSelector.GetTarget(Smite.Range, DamageType.Mixed);
            var Summ2 = TargetSelector.GetTarget(Ignite.Range, DamageType.Mixed);

            if ((Summ1 == null) || Summ1.IsInvulnerable)
                return;
            //Cast Smite
            if (ComboMenu["Smite"].Cast<CheckBox>().CurrentValue)
                if (Summ1.IsValidTarget(Smite.Range) && Smite.IsReady())
                    Smite.Cast(Smite.GetKillableHero());

            if ((Summ2 == null) || Summ2.IsInvulnerable)
                return;
            //Cast Ignite
            if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
                if (Summ2.IsValidTarget(Ignite.Range) && Ignite.IsReady())
                    Ignite.Cast(Ignite.GetKillableHero());
        }
    }
}
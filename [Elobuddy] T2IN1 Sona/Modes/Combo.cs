////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1;
using T2IN1_Lib;
using static T2IN1_Sona.Menus;
using static T2IN1_Sona.SpellsManager;
using static T2IN1_Sona.Offensive;

namespace T2IN1_Sona
{
    internal static class Combo
    {
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemiesInRange(680) >= 1) && Q.IsReady() && Q.IsLearned &&
                    qtarget.IsValidTarget(Q.Range))
                    Q.TryToCast(qtarget, ComboMenu);
        }

        public static void ExecuteItems()
        {
            //Item Target's
            var botrktarget = TargetSelector.GetTarget(Botrk.Range, DamageType.Physical);
            var gunbladetarget = TargetSelector.GetTarget(Gunblade.Range, DamageType.Magical);
            var protobelttarget = TargetSelector.GetTarget(Protobelt.Range, DamageType.Magical);
            var glptarget = TargetSelector.GetTarget(GLP.Range, DamageType.Magical);
            var cutlasstarget = TargetSelector.GetTarget(Cutlass.Range, DamageType.Magical);

            if ((botrktarget == null) || botrktarget.IsInvulnerable)
                return;
            //Blade of the Ruined King
            if (ComboMenu["Botrk"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemiesInRange(550) >= 1) && Botrk.IsReady() && Botrk.IsOwned() &&
                    botrktarget.IsValidTarget(Botrk.Range))
                    Botrk.Cast(botrktarget);

            if ((gunbladetarget == null) || gunbladetarget.IsInvulnerable)
                return;
            //Hextech Gunblade
            if (ComboMenu["Gunblade"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemiesInRange(700) >= 1) && Gunblade.IsReady() && Gunblade.IsOwned() &&
                    gunbladetarget.IsValidTarget(Gunblade.Range))
                    Gunblade.Cast(gunbladetarget);

            if ((protobelttarget == null) || protobelttarget.IsInvulnerable)
                return;
            //Protobelt
            if (ComboMenu["Protobelt"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemiesInRange(600) >= 1) && Protobelt.IsReady() && Protobelt.IsOwned() &&
                    protobelttarget.IsValidTarget(Protobelt.Range))
                    Protobelt.Cast(protobelttarget.Position);

            if ((glptarget == null) || glptarget.IsInvulnerable)
                return;
            //GLP
            if (ComboMenu["GLP"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemiesInRange(600) >= 1) && GLP.IsReady() && GLP.IsOwned() &&
                    glptarget.IsValidTarget(GLP.Range))
                    GLP.Cast(glptarget);

            if ((cutlasstarget == null) || cutlasstarget.IsInvulnerable)
                return;
            //Bilgewater Cutlass
            if (ComboMenu["Cutlass"].Cast<CheckBox>().CurrentValue)
                if ((Player.Instance.CountEnemiesInRange(550) >= 1) && Cutlass.IsReady() && Cutlass.IsOwned() &&
                    cutlasstarget.IsValidTarget(Cutlass.Range))
                    Cutlass.Cast(cutlasstarget);

            /*

            //Summoners Target
            var Summ1 = TargetSelector.GetTarget(Smite.Range, DamageType.Mixed);
            var Summ2 = TargetSelector.GetTarget(Ignite.Range, DamageType.Mixed);

            if ((Summ1 == null) || Summ1.IsInvulnerable)
                return;
            //Smite
            if (ComboMenu["Smite"].Cast<CheckBox>().CurrentValue)
                if (Player.Instance.CountEnemiesInRange(500) >= 1 && Smite.IsReady() && Smite.IsLearned && Summ1.IsValidTarget(Smite.Range))
                    Smite.Cast(Summ1);


            if ((Summ2 == null) || Summ2.IsInvulnerable)
                return;
            //Ignite
            if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
                if (Player.Instance.CountEnemiesInRange(600) >= 1 && Ignite.IsReady() && Ignite.IsLearned && Summ2.IsValidTarget(Ignite.Range))
                    Ignite.Cast(Summ2);

            */
        }
    }
}
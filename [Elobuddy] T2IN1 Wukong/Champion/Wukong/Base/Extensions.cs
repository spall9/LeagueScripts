using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using System.Linq;
using static T2IN1_Wukong.Menus;
using static T2IN1_Wukong.Potions;

namespace T2IN1_Wukong
{
    public static class Extensions
    {
        public static readonly AIHeroClient player = ObjectManager.Player;

        public static void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            if (sender.Owner.IsMe && (args.Slot == SpellSlot.Q || args.Slot == SpellSlot.W || args.Slot == SpellSlot.E))
                if (player.HasBuff("MonkeyKingSpinToWin"))
                    args.Process = false;
        }

        public static bool RIsActive()
        {
            if (ObjectManager.Player.HasBuff("MonkeyKingSpinToWin"))
                return true;

            return false;
        }

        public static bool AutoSmiteIMinions(Obj_AI_Minion minion)
        {
            return minion.IsValidTarget()
                && (minion.Name.ToLower().Contains("baron")
                || minion.Name.ToLower().Contains("dragon")
                || minion.Name.ToLower().Contains("herald"));
        }

        public static AIHeroClient GetKillableHero(this Spell.SpellBase spell)
        {
            return
                EntityManager.Heroes.Enemies.FirstOrDefault(
                    e =>
                        e.IsValidTarget(spell.Range) &&
                        (Prediction.Health.GetPrediction(e, spell.CastDelay) <= e.GetDamage(spell.Slot)) &&
                        !e.HasUndyingBuff());
        }

        public static Obj_AI_Minion GetLastHitMinion(this Spell.SpellBase spell)
        {
            return
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .FirstOrDefault(
                        m =>
                            m.IsValidTarget(spell.Range) &&
                            (Prediction.Health.GetPrediction(m, spell.CastDelay) <= m.GetDamage(spell.Slot)) &&
                            m.IsEnemy);
        }
        public static float GetTotalDamage(this Obj_AI_Base target)
        {
            var slots = new[] { SpellSlot.Q, SpellSlot.E, SpellSlot.R };
            var dmg = Player.Spells.Where(s => slots.Contains(s.Slot)).Sum(s => target.GetDamage(s.Slot));
            dmg += Orbwalker.CanAutoAttack ? Player.Instance.GetAutoAttackDamage(target) : 0f;

            return dmg;
        }

        //Cast Potions
        public static void Potions()
        {
            var HealBuff = Player.HasBuff("RegenerationPotion")
                           || Player.HasBuff("ItemMiniRegenPotion")
                           || Player.HasBuff("ItemCrystalFlask")
                           || Player.HasBuff("ItemDarkCrystalFlask")
                           || Player.HasBuff("ItemCrystalFlaskJungle")
                           || Player.Instance.IsRecalling();

            //Health Potion
            if (JungleClearMenu["HealthPotion"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Health.IsOwned() && Health.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Health.Cast();
            }
            //Hunters Potion
            if (JungleClearMenu["HuntersPotion"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Hunters.IsOwned() && Hunters.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Hunters.Cast();
            }

            //Biscuit
            if (JungleClearMenu["Biscuit"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;
                if (Biscuit.IsOwned() && Biscuit.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Biscuit.Cast();
            }

            //Refillable
            if (JungleClearMenu["Refillable"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Refillable.IsOwned() && Refillable.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Refillable.Cast();
            }

            //Corrupting
            if (JungleClearMenu["Corrupting"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead || HealBuff) return;

                if (Corrupting.IsOwned() && Corrupting.IsReady())
                    if (Player.Instance.HealthPercent <= JungleClearMenu["PotionHp"].Cast<Slider>().CurrentValue)
                        Corrupting.Cast();
            }
        }
    }
}
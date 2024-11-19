using ClassesManagerReborn.Util;
using ModsPlus;
using RarityLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnboundLib;
using UnityEngine;
using Lich.Monos;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;

namespace Lich.Cards
{
    public class LichClassCard : CustomEffectCard<PhylacteryOwner>
    {
        internal static CardInfo card = null;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = LichClassClass.name;
        }

        public override CardDetails Details => new CardDetails
        {
            Title = "Lich Class",
            Description = "Become an undead and protect your phylactery\n<#ffff00><b>UNIQUE CLASS</color></b>",
            ModName = Lich.ModInitials,
            Art = null,
            Rarity = RarityUtils.GetRarity("Legendary"),
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
            Stats = new[]
            {
                new CardInfoStat
                {
                    amount = "-75%",
                    positive = false,
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
                    stat = "Health"
                }
            }
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.respawns = 3;
            statModifiers.health = 0.25f;
            cardInfo.categories = new CardCategory[] { Lich.LichCard, CustomCardCategories.instance.CardCategory("CardManipulation") };
        }
        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Lich.instance.PhyMan.SetupPhylactery(player);
            foreach (var temPlayer in PlayerManager.instance.players)
            {
                if (!ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(temPlayer.data.stats).blacklistedCategories.Contains(Lich.LichCard))
                {
                    ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(temPlayer.data.stats).blacklistedCategories.Add(Lich.LichCard);
                }
            }
        }
    }
}

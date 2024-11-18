using System.Linq;
using ClassesManagerReborn.Util;
using Lich.Monos;
using ModsPlus;
using RarityLib.Utils;
using UnboundLib;
using System.Collections;
using UnboundLib.GameModes;
using Photon.Pun;
using UnityEngine;
using UnboundLib.Networking;
using UnityEngine.Events;

namespace Lich.Cards
{
    public class LifestealConnection : CustomEffectCard<LifestealPhyEffect>
    {
        internal static CardInfo card = null;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = LichClassClass.name;
        }

        public override CardDetails Details => new CardDetails
        {
            Title = "Lifesteal Connection",
            Description = "Damage you deal heals your phylactery",
            ModName = Lich.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
            Stats = new[] 
            {
                new CardInfoStat
                {
                    amount = "+50%",
                    positive = true,
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned,
                    stat = "Lifesteal"
                }
            }
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.lifeSteal = 1.5f;
        }
    }
}
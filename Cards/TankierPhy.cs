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
    public class TankyerPhy : SimpleCard
    {
        internal static CardInfo card = null;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = LichClassClass.name;
        }

        public override CardDetails Details => new CardDetails
        {
            Title = "Tougher Phylactery",
            Description = "Increases Phylactery Health",
            ModName = Lich.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Uncommon,
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
            Stats = new[]
            {
                new CardInfoStat
                {
                    amount = "+50%",
                    positive = true,
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
                    stat = "Phylactery Health"
                }
            }
        };
    }
}
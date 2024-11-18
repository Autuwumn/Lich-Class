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
    public class SelfSafety : SimpleCard
    {
        internal static CardInfo card = null;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = LichClassClass.name;
        }

        public override CardDetails Details => new CardDetails
        {
            Title = "Self Safety",
            Description = "Phylactery can't be hurt by you",
            ModName = Lich.ModInitials,
            Art = null,
            Rarity = RarityUtils.GetRarity("Legendary"),
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
        };
    }
}
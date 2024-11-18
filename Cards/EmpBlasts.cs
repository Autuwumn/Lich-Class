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
    public class EmpBlasts : SimpleCard
    {
        internal static CardInfo card = null;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = LichClassClass.name;
        }

        public override CardDetails Details => new CardDetails
        {
            Title = "Energy Explusion",
            Description = "Every 5 seconds, phylactery release your block effects\nStacking this card reduces cd",
            ModName = Lich.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
        };
    }
}
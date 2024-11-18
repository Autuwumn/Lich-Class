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
    public class EmergencyEvac : SimpleCard
    {
        internal static CardInfo card = null;
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = LichClassClass.name;
        }

        public override CardDetails Details => new CardDetails
        {
            Title = "Emergency Evacuation",
            Description = "At 75%, 50%, and 25% health, the phylactery teleports to you",
            ModName = Lich.ModInitials,
            Art = null,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
        };
    }
}
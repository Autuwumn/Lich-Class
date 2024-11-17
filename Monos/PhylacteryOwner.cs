using ModsPlus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnboundLib.GameModes;
using UnityEngine;

namespace Lich.Monos
{
    public class PhylacteryOwner : CardEffect
    {
        public Phylactery Phy;
        bool PhylacteryAlive = true;
        public override IEnumerator OnRoundStart(IGameModeHandler gameModeHandler)
        {
            if(Phy == null) Phy = Lich.instance.PhyMan.Phys.Where((p) => p.Owner == player).FirstOrDefault();
            Phy.transform.position = player.transform.position;
            PhylacteryAlive = true;
            yield return null;
        }
        public override void OnDealtDamage(Vector2 damage, bool selfDamage)
        {
            if(damage.magnitude >= player.data.health)
            {
                player.transform.position = Phy.transform.position;
            }
        }
    }
}

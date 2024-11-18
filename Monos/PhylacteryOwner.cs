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
        public bool PhylacteryAlive = true;
        public bool hasEMP = false;

        public override IEnumerator OnRoundStart(IGameModeHandler gameModeHandler)
        {
            if(Phy == null) Phy = Lich.instance.PhyMan.Phys.Where((p) => p.Owner == player).FirstOrDefault();
            Phy.transform.position = player.transform.position;
            PhylacteryAlive = true;
            yield return null;
        }
        public void FixedUpdate()
        {
            if (PhylacteryAlive)
            {
                characterStats.remainingRespawns = 999;
                characterStats.respawns = 999;
            } else
            {
                characterStats.remainingRespawns = 0;
                characterStats.respawns = 0;
            }
        }
        public override void OnTakeDamage(Vector2 damage, bool selfDamage)
        {
            if (Phy == null) Phy = Lich.instance.PhyMan.Phys.Where((p) => p.Owner == player).FirstOrDefault();
            if (damage.magnitude >= player.data.health)
            {
                player.transform.position = Phy.transform.position;
            }
        }
    }
}

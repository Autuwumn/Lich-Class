using ModsPlus;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Lich.Monos
{
    public class DotRemover : CardEffect
    {
        public override void OnTakeDamage(Vector2 damage, bool selfDamage)
        {
            player.GetComponent<DamageOverTime>().StopAllCoroutines();
        }
    }
}

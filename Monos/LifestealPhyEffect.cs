using ModsPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Lich.Monos
{
    public class LifestealPhyEffect : CardEffect
    {
        public override void OnDealtDamage(Vector2 damage, bool selfDamage)
        {
            if(!selfDamage)
            {
                var myphy = Lich.instance.PhyMan.Phys.Where((p) => p.Owner == player).FirstOrDefault();
                myphy.GetComponent<DamagableEvent>().currentHP += damage.magnitude*characterStats.lifeSteal/2f;
                if (myphy.GetComponent<DamagableEvent>().currentHP > myphy.GetComponent<DamagableEvent>().maxHP) myphy.GetComponent<DamagableEvent>().currentHP = myphy.GetComponent<DamagableEvent>().maxHP;
                myphy.UpdateHealth();
            }
        }
    }
}

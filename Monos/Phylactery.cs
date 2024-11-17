using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Lich.Monos
{
    public class Phylactery : MonoBehaviour
    {
        public Player Owner;
        public UnityEvent DeathEvent;

        public void Awake()
        {
            DeathEvent.AddListener(KillPhylactery);
            gameObject.GetComponent<DamagableEvent>().deathEvent = DeathEvent;
        }
        public void KillPhylactery()
        {
            print("im dead");
        }
        public void SpawnPhylactery()
        {

        }
    }
}

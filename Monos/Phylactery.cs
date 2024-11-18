using Lich.Cards;
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
        public UnityEvent DamageEvent;

        private int Toughs = 0;
        private bool Evac = false;
        private bool Emp = false;
        private bool SelfSafe = false;

        private float EvacHP = 0;

        private float oldHealth = 100;
        private float newHealth = 100;

        private float cd = 5;
        private float counter = 0;

        private void FixedUpdate()
        {
            if (Emp && !gameObject.GetComponent<DamagableEvent>().dead)
            {
                counter += Time.fixedDeltaTime;
                if (counter > cd)
                {
                    counter = 0;
                    BlastThem();
                }
                if(counter >= 0.1f)
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }
            }
        }
        private void BlastThem()
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            for(var i = 0; i < Owner.transform.childCount; i++)
            {
                var c = Owner.transform.GetChild(i);
                if(c.GetComponent<BlockTrigger>())
                {
                    var blockObj = c.gameObject;
                    blockObj.transform.position = gameObject.transform.position;
                    blockObj.GetComponent<BlockTrigger>().triggerEvent.Invoke();
                    if(blockObj.GetComponent<SpawnObjects>()) blockObj.GetComponent<SpawnObjects>().Spawn();
                    Owner.GetComponent<Block>().CancelInvoke();
                    blockObj.transform.position = Owner.transform.position;
                }
            }
        }
        public void Awake()
        {
            DeathEvent.AddListener(KillPhylactery);
            DamageEvent.AddListener(OnHit);
            gameObject.GetComponent<DamagableEvent>().deathEvent = DeathEvent;
            gameObject.GetComponent<DamagableEvent>().damageEvent = DamageEvent;
        }
        public void KillPhylactery()
        {            
            var de = gameObject.GetComponent<DamagableEvent>();
            if (de.lastPlayer == Owner && SelfSafe) de.currentHP = oldHealth;
            de.dead = false;
            if (de.currentHP <= 0)
            {
                gameObject.transform.position = Vector3.one * 12000;
                Owner.gameObject.GetComponentInChildren<PhylacteryOwner>().PhylacteryAlive = false;
            }

        }
        public void SpawnPhylactery()
        {
            gameObject.transform.position = Owner.transform.position;
            Owner.gameObject.GetComponentInChildren<PhylacteryOwner>().PhylacteryAlive = true;
            Toughs = 0;
            SelfSafe = false;
            Evac = false;
            Emp = false;
            var empMult = 1f/0.75f;
            foreach(var c in Owner.data.currentCards)
            {
                if (c == TankyerPhy.card) Toughs++;
                if (c == SelfSafety.card) SelfSafe = true;
                if (c == EmergencyEvac.card) Evac = true;
                if (c == EmpBlasts.card)
                {
                    Emp = true;
                    empMult *= 0.75f;
                }
            }
            cd = 5f * empMult;
            if (Evac) EvacHP = 0.75f;
            var de = gameObject.GetComponent<DamagableEvent>();
            de.maxHP = 100 * Mathf.Pow(1.5f, Toughs);
            de.currentHP = de.maxHP;

            UpdateHealth();
        }
        public void UpdateHealth()
        {
            var de = gameObject.GetComponent<DamagableEvent>();
            gameObject.GetComponent<SpriteRenderer>().color = PlayerManager.instance.GetColorFromPlayer(Owner.playerID).color * new Vector4(0.2f + de.currentHP / de.maxHP, 0.2f + de.currentHP / de.maxHP, 0.2f + de.currentHP / de.maxHP, 1);
        }
        public void OnHit()
        {
            var de = gameObject.GetComponent<DamagableEvent>();
            oldHealth = newHealth;
            if (de.lastPlayer == Owner && SelfSafe) de.currentHP = oldHealth;
            newHealth = de.currentHP;

            if (de.currentHP/de.maxHP < EvacHP && Evac)
            {
                if(de.currentHP/de.maxHP > 0.5f)
                {
                    EvacHP = 0.5f;
                } else if(de.currentHP/de.maxHP > 0.25f)
                {
                    EvacHP = 0.25f;
                } else
                {
                    EvacHP = 0;
                }
                gameObject.transform.position = Owner.transform.position;
            }
            UpdateHealth();
        }
    }
}

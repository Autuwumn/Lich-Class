using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnboundLib.Networking;
using UnboundLib;
using System.Linq;
using ModsPlus;

namespace Lich.Monos
{
    public class PhylacteryManager : MonoBehaviour
    {
        public Phylactery[] Phys = new Phylactery[] { };

        public void SetupPhylactery(Player owner)
        {
            if (!PhotonNetwork.IsMasterClient) return; 
            var curPhy = PhotonNetwork.Instantiate("Lich_Phylactery", owner.transform.position, Quaternion.identity);
            NetworkingManager.RPC(typeof(PhylacteryManager), nameof(RPC_SyncOwner), owner.playerID);
        }
        [UnboundRPC]
        public static void RPC_SyncOwner(int ownerid)
        {
            foreach(var phy in FindObjectsOfType<Phylactery>())
            {
                if(Vector3.Distance(PlayerManager.instance.GetPlayerWithID(ownerid).transform.position, phy.transform.position) < 10 && phy.Owner == null)
                {
                    phy.Owner = PlayerManager.instance.GetPlayerWithID(ownerid);
                    Lich.instance.PhyMan.Phys.Append(phy);
                }
            }
        }
    }
}

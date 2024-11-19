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
using Photon.Pun.Simple;

namespace Lich.Monos
{
    public class PhylacteryManager : MonoBehaviour
    {
        public List<Phylactery> Phys = new List<Phylactery>{ };

        public void SetupPhylactery(Player owner)
        {
            if (!PhotonNetwork.IsMasterClient || PhotonNetwork.OfflineMode) return;
            var curPhy = PhotonNetwork.Instantiate("Lich_Phylactery", owner.transform.position, Quaternion.identity);
            Lich.instance.ExecuteAfterFrames(10, () =>
            {
                var ownerid = owner.playerID;
                foreach (var phy in FindObjectsOfType<Phylactery>())
                {
                    if (phy.Owner == null)
                    {
                        phy.Owner = PlayerManager.instance.GetPlayerWithID(ownerid);
                        Lich.instance.PhyMan.Phys.Add(phy);
                    }
                }
            });
            
            NetworkingManager.RPC_Others(typeof(PhylacteryManager), nameof(RPC_SyncOwner), owner.playerID);
            /**var phy = curPhy.GetComponent<Phylactery>();
            phy.Owner = owner;
            Lich.instance.PhyMan.Phys.Add(phy);
            phy.SpawnPhylactery();**/
        }
        [UnboundRPC]
        public static void RPC_SyncOwner(int ownerid)
        {
            foreach(var phy in FindObjectsOfType<Phylactery>())
            {
                if(phy.Owner == null)
                {
                    phy.Owner = PlayerManager.instance.GetPlayerWithID(ownerid);
                    Lich.instance.PhyMan.Phys.Add(phy);
                }
            }
        }
    }
}

using BepInEx;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using HarmonyLib;
using Jotunn.Utils;
using Lich.Monos;
using Photon.Pun;
using System;
using UnboundLib.Cards;
using UnityEngine;
using Lich.Cards;
using ModsPlus;
using System.Linq;
using System.Reflection;

namespace Lich
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.classes.manager.reborn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.rarity.lib", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.cardtheme.lib", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.CrazyCoders.Rounds.RarityBundle", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class Lich : BaseUnityPlugin
    {
        private const string ModId = "koala.lichclass";
        private const string ModName = "Lich Class";
        public const string Version = "0.0.0";
        public const string ModInitials = "LICH";

        public static Lich instance;

        internal static AssetBundle LichAssets;

        public PhylacteryManager PhyMan;

        internal static CardCategory LichCard;

        public static GameObject empEffect;

        void Start()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
            if (!instance) instance = this; else Destroy(this);

            var bhyMan = new GameObject("Phylactery Manager");
            PhyMan = bhyMan.AddComponent<PhylacteryManager>();
            DontDestroyOnLoad(bhyMan);

            LichAssets = AssetUtils.LoadAssetBundleFromResources("lichassetbundle", typeof(Lich).Assembly);
            if (!LichAssets) UnityEngine.Debug.Log("Lich Asset bundle either doesn't exist or failed to load.");

            var lichObj = LichAssets.LoadAsset<GameObject>("Phylactery");
            lichObj.AddComponent<Phylactery>();
            lichObj.layer = 8;
            PhotonNetwork.PrefabPool.RegisterPrefab("Lich_Phylactery", lichObj);

            LichCard = CustomCardCategories.instance.CardCategory("LichCard");

            var fieldInfo = typeof(UnboundLib.Utils.CardManager).GetField("defaultCards", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            var vanillaCards = (CardInfo[])fieldInfo.GetValue(null);
            var empCard = vanillaCards.Where((c) => c.cardName.ToLower() == "emp").ToArray()[0];
            empEffect = empCard.gameObject.GetComponent<CharacterStatModifiers>().AddObjectToPlayer.gameObject;

            CustomCard.BuildCard<LichClassCard>((card) => { LichClassCard.card = card; card.SetAbbreviation("Lc"); });
            CustomCard.BuildCard<TankyerPhy>((card) => { TankyerPhy.card = card; card.SetAbbreviation("Tp"); });
            CustomCard.BuildCard<SelfSafety>((card) => { SelfSafety.card = card; card.SetAbbreviation("Ss"); });
            CustomCard.BuildCard<LifestealConnection>((card) => { LifestealConnection.card = card; card.SetAbbreviation("Lc"); });
            CustomCard.BuildCard<UndeadBody>((card) => { UndeadBody.card = card; card.SetAbbreviation("Ub"); });
            CustomCard.BuildCard<EmergencyEvac>((card) => { EmergencyEvac.card = card; card.SetAbbreviation("Ee"); });
            CustomCard.BuildCard<EmpBlasts>((card) => { EmpBlasts.card = card; card.SetAbbreviation("Ee"); });
        }
    }
}

using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ExampleShowTamed
{
    [BepInPlugin("ellseni.waterOverride", "Valheim Mod", "0.0.1")]
    [BepInProcess("valheim.exe")]
    public class waterOverride : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("ellseni.waterOverride");

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(WaterVolume), nameof(WaterVolume.GetLiquidType))]
        class TarWater_Patch
        {
            static void Prefix(ref int ____depth)
            {
                Debug.Log($"____depth: {____depth}");
                //____depth = 15;
            }
        }

    }
}
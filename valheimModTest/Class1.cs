﻿using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ExampleShowTamed
{
    [BepInPlugin("dickdangerjustice.ValheimModTest", "Valheim Mod", "0.0.1")]
    [BepInProcess("valheim.exe")]
    public class ValheimModTest : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("dickdangerjustice.ValheimModTest");

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Character), nameof(Character.Jump))]
        class Jump_Patch
        {
            static void Prefix(ref float ___m_jumpForce)
            {
                Debug.Log($"Jump force: {___m_jumpForce}");
                ___m_jumpForce = 15;
                Debug.Log($"Modified jump force: {___m_jumpForce}");
            }
        }
    }
}
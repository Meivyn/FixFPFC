using HarmonyLib;
using UnityEngine;

namespace FixFPFC.HarmonyPatches
{
    [HarmonyPatch(typeof(OVRPlugin), nameof(OVRPlugin.hasInputFocus), MethodType.Getter)]
    internal class HasInputFocusGetterPatch
    {
        private static FirstPersonFlyingController firstPersonFlyingController;

        private static void Postfix(ref bool __result)
        {
            firstPersonFlyingController = firstPersonFlyingController ?? Object.FindObjectOfType<FirstPersonFlyingController>();

            if (firstPersonFlyingController == null)
            {
                return;
            }

            __result = firstPersonFlyingController.enabled;
        }
    }
}


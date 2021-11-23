using HarmonyLib;
using UnityEngine;

namespace FixFPFC.HarmonyPatches
{
    [HarmonyPatch(typeof(OVRPlugin), nameof(OVRPlugin.hasInputFocus), MethodType.Getter)]
    internal class OVRPluginHasInputFocusGetterPatch
    {
        private static FirstPersonFlyingController firstPersonFlyingController;

        private static void Postfix(ref bool __result)
        {
            if (firstPersonFlyingController == null)
            {
                firstPersonFlyingController = Object.FindObjectOfType<FirstPersonFlyingController>();
            }

            if (firstPersonFlyingController != null && firstPersonFlyingController.enabled)
            {
                __result = true;
            }
        }
    }
}

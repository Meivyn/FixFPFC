using HarmonyLib;
using System;
using System.Linq;

namespace OculusFPFCFix
{
    class HarmonyPatches
    {
        [HarmonyPatch(typeof(OVRPlugin), "hasInputFocus", MethodType.Getter)]
        private class POVRPlugin
        {
            internal static void Postfix(ref bool __result)
            {
                if (Environment.GetCommandLineArgs().Contains("fpfc"))
                    __result = true;
            }
        }
    }
}

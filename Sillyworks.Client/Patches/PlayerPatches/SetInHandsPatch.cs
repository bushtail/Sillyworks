using System.Collections;
using System.Reflection;
using Comfort.Common;
using EFT;
using EFT.InventoryLogic;
using HarmonyLib;
using SPT.Reflection.Patching;
using UnityEngine;

namespace Sillyworks.Client.Patches.PlayerPatches;

public class SetInHandsPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(
            typeof(Player), 
            nameof(Player.SetInHands),
            [
                typeof(FoodDrink), 
                typeof(float), 
                typeof(int), 
                typeof(Callback<IMedsController>)
            ]
        );
    }

    [PatchPrefix]
    internal static void Prefix(Player __instance, FoodDrink foodDrink, float amount, int animationVariant, Callback<IMedsController> callback)
    {
        if (!foodDrink.TemplateId.EqualsToString("6a90ba446acf8828b44523c8")) { return; }

        Plugin.Instance!.StartCoroutine(WaitThenExplodeAt(__instance, foodDrink));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private static IEnumerator WaitThenExplodeAt(Player player, Item item)
    {
        yield return new WaitForSecondsRealtime(2.55f);

        WTTClientCommonLib.Helpers.ExplosionHelper.DetonateAt(player.CameraPosition.position/*, item, player, 0.1f, 0.5f, 15, 80*/);
    }
}
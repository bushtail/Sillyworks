using BepInEx;
using Sillyworks.Client.Patches.PlayerPatches;

namespace Sillyworks.Client;

[BepInPlugin("ca.bushtail.sillyworks", "Sillyworks Client", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    internal static Plugin? Instance;
    
    internal void Awake()
    {
        Instance = this;
        new SetInHandsPatch().Enable();
    }
}
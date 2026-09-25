using System.Reflection;
using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using WTTServerCommonLib.Models;

namespace Sillyworks.Server;

[Injectable(TypePriority = OnLoadOrder.Preload + 1), UsedImplicitly]
public class Sillyworks(WTTServerCommonLib.WTTServerCommonLib wttServerCommonLib) : IOnLoad
{
    internal readonly MongoId traderId = new("6ab5da734a1b005364c19e9d");
    
    public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        TraderIds.Add("MILO", traderId);
        
        await wttServerCommonLib.CustomItemServiceExtended.CreateCustomItems(assembly);
    }
}
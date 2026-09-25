using System.Reflection;
using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;

namespace Sillyworks.Server;

[Injectable(TypePriority = OnLoadOrder.Preload + 1), UsedImplicitly]
public class Sillyworks(WTTServerCommonLib.WTTServerCommonLib wttServerCommonLib) : IOnLoad
{
    public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();
        await wttServerCommonLib.CustomItemServiceExtended.CreateCustomItems(assembly);
    }
}
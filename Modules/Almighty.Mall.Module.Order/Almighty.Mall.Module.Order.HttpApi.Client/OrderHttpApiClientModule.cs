using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Almighty.Mall.Module.Order;

[DependsOn(
    typeof(OrderApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class OrderHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(OrderApplicationContractsModule).Assembly,
            OrderRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrderHttpApiClientModule>();
        });

    }
}

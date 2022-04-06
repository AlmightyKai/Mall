using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Almighty.Mall.Module.Seller;

[DependsOn(
    typeof(SellerApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SellerHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SellerApplicationContractsModule).Assembly,
            SellerRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SellerHttpApiClientModule>();
        });

    }
}

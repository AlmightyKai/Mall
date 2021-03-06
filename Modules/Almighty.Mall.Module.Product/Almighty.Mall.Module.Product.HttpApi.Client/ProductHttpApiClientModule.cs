using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(typeof(ApplicationContractsModule), typeof(AbpHttpClientModule))]
    public class ProductHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(ApplicationContractsModule).Assembly, RemoteServiceConsts.RemoteServiceName);

            this.Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProductHttpApiClientModule>();
            });
        }
    }
}

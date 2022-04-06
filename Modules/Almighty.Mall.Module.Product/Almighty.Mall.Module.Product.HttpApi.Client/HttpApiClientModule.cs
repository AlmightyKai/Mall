using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Almighty.Mall.Module.Product
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(ApplicationContractsModule), typeof(AbpHttpClientModule))]
    public class HttpApiClientModule : AbpModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(ApplicationContractsModule).Assembly, RemoteServiceConsts.RemoteServiceName);

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HttpApiClientModule>();
            });

        }
    }
}

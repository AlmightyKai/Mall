using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Kai.Mall.Module.Product
{
    [DependsOn(typeof(DomainModule), typeof(ApplicationContractsModule), typeof(AbpDddApplicationModule), typeof(AbpAutoMapperModule))]
    public class ApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ApplicationModule>(validate: true);
            });
        }
    }
}

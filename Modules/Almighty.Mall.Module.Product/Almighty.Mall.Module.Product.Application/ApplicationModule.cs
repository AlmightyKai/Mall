using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(typeof(DomainModule), typeof(ApplicationContractsModule), typeof(AbpDddApplicationModule), typeof(AbpAutoMapperModule))]
    public class ApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ApplicationModule>();
            
            this.Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ApplicationModule>(validate: true);
            });
        }
    }
}

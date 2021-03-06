using Localization.Resources.AbpUi;
using Almighty.Mall.Module.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(typeof(ApplicationContractsModule), typeof(AbpAspNetCoreMvcModule))]
    public class ProductHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            this.PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            this.Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ProductResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}

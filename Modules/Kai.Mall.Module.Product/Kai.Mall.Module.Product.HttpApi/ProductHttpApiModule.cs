using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Kai.Mall.Module.Product.Localization;

namespace Kai.Mall.Module.Product
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(ApplicationContractsModule), typeof(AbpAspNetCoreMvcModule))]
    public class ProductHttpApiModule : AbpModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductHttpApiModule).Assembly);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<ProductResource>().AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}

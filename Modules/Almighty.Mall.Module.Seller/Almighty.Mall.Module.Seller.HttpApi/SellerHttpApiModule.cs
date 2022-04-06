using Localization.Resources.AbpUi;
using Almighty.Mall.Module.Seller.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Almighty.Mall.Module.Seller;

[DependsOn(
    typeof(SellerApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SellerHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SellerHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SellerResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}

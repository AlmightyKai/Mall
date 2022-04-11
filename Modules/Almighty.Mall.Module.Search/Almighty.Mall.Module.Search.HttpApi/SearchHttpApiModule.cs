﻿using Localization.Resources.AbpUi;
using Almighty.Mall.Module.Search.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Almighty.Mall.Module.Search;

[DependsOn(
    typeof(SearchApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SearchHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SearchHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SearchResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}

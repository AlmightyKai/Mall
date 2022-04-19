using Almighty.Mall.Module.Product.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(typeof(AbpValidationModule))]
    public class DomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            this.Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<DomainSharedModule>();
            });

            this.Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProductResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Product");
            });

            this.Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Product", typeof(ProductResource));
            });
        }
    }
}

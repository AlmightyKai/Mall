using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(
    typeof(ProductDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
    public class ApplicationContractsModule : AbpModule
    {

    }
}

using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(typeof(DomainSharedModule), typeof(AbpDddApplicationContractsModule), typeof(AbpAuthorizationModule))]
    public class ApplicationContractsModule : AbpModule
    {

    }
}

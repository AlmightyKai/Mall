using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Almighty.Mall.Module.Order;

[DependsOn(
    typeof(OrderDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class OrderApplicationContractsModule : AbpModule
{

}

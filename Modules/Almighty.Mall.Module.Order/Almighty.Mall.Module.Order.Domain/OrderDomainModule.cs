using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Almighty.Mall.Module.Order;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(OrderDomainSharedModule)
)]
public class OrderDomainModule : AbpModule
{

}

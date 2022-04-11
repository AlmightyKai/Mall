using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Almighty.Mall.Module.Payment;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PaymentDomainSharedModule)
)]
public class PaymentDomainModule : AbpModule
{

}

using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Almighty.Mall.Module.Seller;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SellerDomainSharedModule)
)]
public class SellerDomainModule : AbpModule
{

}

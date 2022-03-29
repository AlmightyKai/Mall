using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Kai.Mall.Module.Product
{
    [DependsOn(typeof(AbpDddDomainModule), typeof(ProductDomainSharedModule))]
    public class DomainModule : AbpModule
    {

    }
}

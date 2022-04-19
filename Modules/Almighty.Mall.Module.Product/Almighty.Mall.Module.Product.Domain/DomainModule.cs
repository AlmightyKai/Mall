using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Almighty.Mall.Module.Product
{
    [DependsOn(typeof(AbpDddDomainModule), typeof(DomainSharedModule))]
    public class DomainModule : AbpModule
    {

    }
}

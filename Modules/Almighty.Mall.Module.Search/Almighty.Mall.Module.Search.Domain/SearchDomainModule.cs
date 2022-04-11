using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Almighty.Mall.Module.Search;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SearchDomainSharedModule)
)]
public class SearchDomainModule : AbpModule
{

}

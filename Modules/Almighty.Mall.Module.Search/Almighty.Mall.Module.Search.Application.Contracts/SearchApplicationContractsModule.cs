using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Almighty.Mall.Module.Search;

[DependsOn(
    typeof(SearchDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SearchApplicationContractsModule : AbpModule
{

}

using Almighty.Mall.Module.Search.Localization;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Search;

public abstract class SearchAppService : ApplicationService
{
    protected SearchAppService()
    {
        LocalizationResource = typeof(SearchResource);
        ObjectMapperContext = typeof(SearchApplicationModule);
    }
}

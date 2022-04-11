using Almighty.Mall.Module.Search.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Almighty.Mall.Module.Search;

public abstract class SearchController : AbpControllerBase
{
    protected SearchController()
    {
        LocalizationResource = typeof(SearchResource);
    }
}

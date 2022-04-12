using Almighty.Mall.Module.Product.Localization;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Product;

public abstract class ProductAppService : ApplicationService
{
    protected ProductAppService()
    {
        LocalizationResource = typeof(ProductResource);
        ObjectMapperContext = typeof(ProductApplicationModule);
    }
}

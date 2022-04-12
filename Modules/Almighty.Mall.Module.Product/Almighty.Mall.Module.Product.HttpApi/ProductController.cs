using Almighty.Mall.Module.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Almighty.Mall.Module.Product;

public abstract class ProductController : AbpControllerBase
{
    protected ProductController()
    {
        LocalizationResource = typeof(ProductResource);
    }
}

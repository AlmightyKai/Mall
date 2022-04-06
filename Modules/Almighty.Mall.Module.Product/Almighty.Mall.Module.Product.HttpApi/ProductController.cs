using Volo.Abp.AspNetCore.Mvc;
using Almighty.Mall.Module.Product.Localization;

namespace Almighty.Mall.Module.Product
{
    public abstract class ProductController : AbpControllerBase
    {
        protected ProductController()
        {
            LocalizationResource = typeof(ProductResource);
        }
    }
}

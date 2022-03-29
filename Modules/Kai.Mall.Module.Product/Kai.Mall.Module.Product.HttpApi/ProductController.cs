using Volo.Abp.AspNetCore.Mvc;
using Kai.Mall.Module.Product.Localization;

namespace Kai.Mall.Module.Product
{
    public abstract class ProductController : AbpControllerBase
    {
        protected ProductController()
        {
            LocalizationResource = typeof(ProductResource);
        }
    }
}

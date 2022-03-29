using Kai.Mall.Module.Product.Localization;
using Volo.Abp.Application.Services;

namespace Kai.Mall.Module.Product
{
    public abstract class AppService : ApplicationService
    {
        protected AppService()
        {
            LocalizationResource = typeof(ProductResource);
            ObjectMapperContext = typeof(ApplicationModule);
        }
    }
}

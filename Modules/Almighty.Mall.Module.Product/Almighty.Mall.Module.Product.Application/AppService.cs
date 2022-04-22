using Almighty.Mall.Module.Product.Localization;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Product
{
    public abstract class AppService : ApplicationService
    {
        protected AppService()
        {
            this.LocalizationResource = typeof(ProductResource);
            this.ObjectMapperContext  = typeof(ApplicationModule);
        }
    }
}

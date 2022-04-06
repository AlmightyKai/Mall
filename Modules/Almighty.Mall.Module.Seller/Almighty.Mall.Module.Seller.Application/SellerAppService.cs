using Almighty.Mall.Module.Seller.Localization;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Seller;

public abstract class SellerAppService : ApplicationService
{
    protected SellerAppService()
    {
        LocalizationResource = typeof(SellerResource);
        ObjectMapperContext = typeof(SellerApplicationModule);
    }
}

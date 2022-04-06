using Almighty.Mall.Module.Seller.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Almighty.Mall.Module.Seller;

public abstract class SellerController : AbpControllerBase
{
    protected SellerController()
    {
        LocalizationResource = typeof(SellerResource);
    }
}

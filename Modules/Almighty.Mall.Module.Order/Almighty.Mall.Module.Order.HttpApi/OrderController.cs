using Almighty.Mall.Module.Order.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Almighty.Mall.Module.Order;

public abstract class OrderController : AbpControllerBase
{
    protected OrderController()
    {
        LocalizationResource = typeof(OrderResource);
    }
}

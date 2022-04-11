using Almighty.Mall.Module.Order.Localization;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Order;

public abstract class OrderAppService : ApplicationService
{
    protected OrderAppService()
    {
        LocalizationResource = typeof(OrderResource);
        ObjectMapperContext = typeof(OrderApplicationModule);
    }
}

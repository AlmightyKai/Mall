using Almighty.Mall.Module.Payment.Localization;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Payment;

public abstract class PaymentAppService : ApplicationService
{
    protected PaymentAppService()
    {
        LocalizationResource = typeof(PaymentResource);
        ObjectMapperContext = typeof(PaymentApplicationModule);
    }
}

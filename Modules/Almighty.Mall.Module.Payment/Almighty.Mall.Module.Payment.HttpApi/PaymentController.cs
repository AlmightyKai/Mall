using Almighty.Mall.Module.Payment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Almighty.Mall.Module.Payment;

public abstract class PaymentController : AbpControllerBase
{
    protected PaymentController()
    {
        LocalizationResource = typeof(PaymentResource);
    }
}

﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Almighty.Mall.Module.Payment;

[DependsOn(
    typeof(PaymentDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PaymentApplicationContractsModule : AbpModule
{

}

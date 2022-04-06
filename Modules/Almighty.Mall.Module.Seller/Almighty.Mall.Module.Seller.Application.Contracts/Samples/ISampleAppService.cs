﻿using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Seller.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}

using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Payment.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}

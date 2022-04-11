using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Almighty.Mall.Module.Search.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}

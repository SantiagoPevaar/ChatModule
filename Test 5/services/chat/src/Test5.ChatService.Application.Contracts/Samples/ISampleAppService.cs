using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Test5.ChatService.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}

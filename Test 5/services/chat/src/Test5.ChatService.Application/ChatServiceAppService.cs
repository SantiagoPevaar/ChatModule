using Test5.ChatService.Localization;
using Volo.Abp.Application.Services;

namespace Test5.ChatService;

public abstract class ChatServiceAppService : ApplicationService
{
    protected ChatServiceAppService()
    {
        LocalizationResource = typeof(ChatServiceResource);
        ObjectMapperContext = typeof(ChatServiceApplicationModule);
    }
}

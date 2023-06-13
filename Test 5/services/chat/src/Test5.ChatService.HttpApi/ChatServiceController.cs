using Test5.ChatService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Test5.ChatService;

public abstract class ChatServiceController : AbpControllerBase
{
    protected ChatServiceController()
    {
        LocalizationResource = typeof(ChatServiceResource);
    }
}

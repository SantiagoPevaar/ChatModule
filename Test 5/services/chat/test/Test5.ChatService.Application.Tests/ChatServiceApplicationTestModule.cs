using Volo.Abp.Modularity;

namespace Test5.ChatService;

[DependsOn(
    typeof(ChatServiceApplicationModule),
    typeof(ChatServiceDomainTestModule)
    )]
public class ChatServiceApplicationTestModule : AbpModule
{

}

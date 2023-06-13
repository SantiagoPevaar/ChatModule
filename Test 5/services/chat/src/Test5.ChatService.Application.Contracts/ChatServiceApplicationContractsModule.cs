using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Chat;

namespace Test5.ChatService;

[DependsOn(
    typeof(ChatServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(ChatApplicationContractsModule))]
    public class ChatServiceApplicationContractsModule : AbpModule
{

}

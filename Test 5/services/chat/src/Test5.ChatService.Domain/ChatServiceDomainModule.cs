using Volo.Abp.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using Volo.Chat;

namespace Test5.ChatService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(ChatServiceDomainSharedModule)
)]
[DependsOn(typeof(ChatDomainModule))]
    public class ChatServiceDomainModule : AbpModule
{
}

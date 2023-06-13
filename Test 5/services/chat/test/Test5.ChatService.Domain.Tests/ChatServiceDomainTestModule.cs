using Test5.ChatService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Test5.ChatService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ChatServiceEntityFrameworkCoreTestModule)
    )]
public class ChatServiceDomainTestModule : AbpModule
{

}

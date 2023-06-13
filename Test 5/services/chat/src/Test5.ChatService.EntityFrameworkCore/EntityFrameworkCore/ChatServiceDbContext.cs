using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;

namespace Test5.ChatService.EntityFrameworkCore;

[ConnectionStringName(ChatServiceDbProperties.ConnectionStringName)]
public class ChatServiceDbContext : AbpDbContext<ChatServiceDbContext>
{

    public ChatServiceDbContext(DbContextOptions<ChatServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureChatService();
        builder.ConfigureChat();
        }
}

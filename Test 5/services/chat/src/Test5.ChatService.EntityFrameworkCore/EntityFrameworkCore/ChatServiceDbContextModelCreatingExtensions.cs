using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Test5.ChatService.EntityFrameworkCore;

public static class ChatServiceDbContextModelCreatingExtensions
{
    public static void ConfigureChatService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ChatServiceConsts.DbTablePrefix + "YourEntities", ChatServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}

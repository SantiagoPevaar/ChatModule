using Microsoft.EntityFrameworkCore;
using Test1.ProductService.Products;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Chat.Conversations;
using Volo.Chat.EntityFrameworkCore;
using Volo.Chat.Messages;
using Volo.Chat.Users;

namespace Test1.ProductService.EntityFrameworkCore;

[ConnectionStringName(ProductServiceDbProperties.ConnectionStringName)]
public class ProductServiceDbContext : AbpDbContext<ProductServiceDbContext>, IChatDbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Message> ChatMessages => throw new System.NotImplementedException();

    public DbSet<ChatUser> ChatUsers => throw new System.NotImplementedException();

    public DbSet<UserMessage> ChatUserMessages => throw new System.NotImplementedException();

    public DbSet<Conversation> ChatConversations => throw new System.NotImplementedException();

    public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProductService();
        builder.ConfigureChat();
        }
}

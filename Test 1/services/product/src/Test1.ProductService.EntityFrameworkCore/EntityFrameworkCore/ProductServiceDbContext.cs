using Microsoft.EntityFrameworkCore;
using Test1.ProductService.Products;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;

namespace Test1.ProductService.EntityFrameworkCore;

[ConnectionStringName(ProductServiceDbProperties.ConnectionStringName)]
public class ProductServiceDbContext : AbpDbContext<ProductServiceDbContext>
{
    public DbSet<Product> Products { get; set; }

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

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Chat;

namespace Test_2.ProductService;

[DependsOn(
    typeof(ProductServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
[DependsOn(typeof(ChatHttpApiClientModule))]
    public class ProductServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(typeof(ProductServiceApplicationContractsModule).Assembly,
            ProductServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProductServiceHttpApiClientModule>();
        });
    }
}

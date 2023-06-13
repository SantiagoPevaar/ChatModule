using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Chat;

namespace Test5.ChatService;

[DependsOn(
    typeof(ChatServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
[DependsOn(typeof(ChatHttpApiClientModule))]
    public class ChatServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(ChatServiceApplicationContractsModule).Assembly,
            ChatServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ChatServiceHttpApiClientModule>();
        });
    }
}

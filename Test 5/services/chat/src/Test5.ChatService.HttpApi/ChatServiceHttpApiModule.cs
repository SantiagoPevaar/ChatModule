using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Test5.ChatService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Chat;

namespace Test5.ChatService;

[DependsOn(
    typeof(ChatServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(ChatHttpApiModule))]
    public class ChatServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ChatServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ChatServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}

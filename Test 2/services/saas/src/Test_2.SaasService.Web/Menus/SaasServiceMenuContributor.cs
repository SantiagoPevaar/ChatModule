using System.Threading.Tasks;
using Test_2.SaasService.Localization;
using Volo.Abp.UI.Navigation;

namespace Test_2.SaasService.Web.Menus;

public class SaasServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SaasServiceResource>();
        return Task.CompletedTask;
    }
}

using System.Threading.Tasks;
using Test1.IdentityService.Localization;
using Volo.Abp.UI.Navigation;

namespace Test1.IdentityService.Web.Menus;

public class IdentityServiceMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<IdentityServiceResource>();
        return Task.CompletedTask;
    }
}

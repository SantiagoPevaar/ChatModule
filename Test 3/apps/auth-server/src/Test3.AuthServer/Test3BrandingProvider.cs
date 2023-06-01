using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Test3.AuthServer;

[Dependency(ReplaceServices = true)]
public class Test3BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Test3";
}

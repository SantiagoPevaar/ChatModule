using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Test1.AuthServer;

[Dependency(ReplaceServices = true)]
public class Test1BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Test1";
}

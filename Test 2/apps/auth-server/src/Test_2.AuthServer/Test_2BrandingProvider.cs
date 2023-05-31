using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Test_2.AuthServer;

[Dependency(ReplaceServices = true)]
public class Test_2BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Test_2";
}

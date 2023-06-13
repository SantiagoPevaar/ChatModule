using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Test5.PublicWeb;

[Dependency(ReplaceServices = true)]
public class Test5BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Test5";
}

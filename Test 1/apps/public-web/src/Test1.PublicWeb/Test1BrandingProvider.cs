using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Test1.PublicWeb;

[Dependency(ReplaceServices = true)]
public class Test1BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Test1";
}

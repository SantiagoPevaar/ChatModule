using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Test4.PublicWeb;

[Dependency(ReplaceServices = true)]
public class Test4BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Test4";
}

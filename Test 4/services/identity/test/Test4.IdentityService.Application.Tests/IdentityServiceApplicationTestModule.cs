using Volo.Abp.Modularity;

namespace Test4.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceDomainTestModule)
    )]
public class IdentityServiceApplicationTestModule : AbpModule
{

}

using Test_2.SaasService.Application;
using Volo.Abp.Modularity;

namespace Test_2.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}

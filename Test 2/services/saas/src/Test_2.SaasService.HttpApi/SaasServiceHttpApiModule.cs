using Volo.Abp.Modularity;
using Volo.Saas.Host;
using Volo.Saas.Tenant;
using Volo.Payment.Admin;

namespace Test_2.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationContractsModule),
    typeof(SaasHostHttpApiModule),
    typeof(SaasTenantHttpApiModule),
    typeof(AbpPaymentAdminHttpApiModule)
)]
public class SaasServiceHttpApiModule : AbpModule
{
}

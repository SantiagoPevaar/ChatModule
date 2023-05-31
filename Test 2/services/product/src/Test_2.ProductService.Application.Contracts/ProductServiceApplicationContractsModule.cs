using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Chat;

namespace Test_2.ProductService;

[DependsOn(
    typeof(ProductServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(ChatApplicationContractsModule))]
    public class ProductServiceApplicationContractsModule : AbpModule
{

}

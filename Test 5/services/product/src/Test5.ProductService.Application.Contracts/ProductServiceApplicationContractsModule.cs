using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Test5.ProductService;

[DependsOn(
    typeof(ProductServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ProductServiceApplicationContractsModule : AbpModule
{

}

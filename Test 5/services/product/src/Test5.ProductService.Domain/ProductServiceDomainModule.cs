using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Test5.ProductService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductServiceDomainSharedModule)
)]
public class ProductServiceDomainModule : AbpModule
{

}

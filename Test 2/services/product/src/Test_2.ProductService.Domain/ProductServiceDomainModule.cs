using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Chat;

namespace Test_2.ProductService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductServiceDomainSharedModule)
)]
[DependsOn(typeof(ChatDomainModule))]
    public class ProductServiceDomainModule : AbpModule
{

}

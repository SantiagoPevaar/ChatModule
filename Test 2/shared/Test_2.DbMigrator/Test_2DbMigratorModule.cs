using Test_2.AdministrationService;
using Test_2.AdministrationService.EntityFrameworkCore;
using Test_2.IdentityService;
using Test_2.IdentityService.EntityFrameworkCore;
using Test_2.ProductService;
using Test_2.ProductService.EntityFrameworkCore;
using Test_2.SaasService;
using Test_2.SaasService.EntityFrameworkCore;
using Test_2.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Test_2.DbMigrator;

[DependsOn(
    typeof(Test_2SharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class Test_2DbMigratorModule : AbpModule
{

}

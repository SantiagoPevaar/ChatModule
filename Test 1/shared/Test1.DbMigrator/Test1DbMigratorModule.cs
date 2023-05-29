using Test1.AdministrationService;
using Test1.AdministrationService.EntityFrameworkCore;
using Test1.IdentityService;
using Test1.IdentityService.EntityFrameworkCore;
using Test1.ProductService;
using Test1.ProductService.EntityFrameworkCore;
using Test1.SaasService;
using Test1.SaasService.EntityFrameworkCore;
using Test1.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Test1.DbMigrator;

[DependsOn(
    typeof(Test1SharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class Test1DbMigratorModule : AbpModule
{

}

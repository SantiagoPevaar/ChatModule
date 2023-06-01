using Test3.AdministrationService;
using Test3.AdministrationService.EntityFrameworkCore;
using Test3.IdentityService;
using Test3.IdentityService.EntityFrameworkCore;
using Test3.ProductService;
using Test3.ProductService.EntityFrameworkCore;
using Test3.SaasService;
using Test3.SaasService.EntityFrameworkCore;
using Test3.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Test3.DbMigrator;

[DependsOn(
    typeof(Test3SharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class Test3DbMigratorModule : AbpModule
{

}

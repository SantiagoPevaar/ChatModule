using Test4.AdministrationService;
using Test4.AdministrationService.EntityFrameworkCore;
using Test4.IdentityService;
using Test4.IdentityService.EntityFrameworkCore;
using Test4.ProductService;
using Test4.ProductService.EntityFrameworkCore;
using Test4.SaasService;
using Test4.SaasService.EntityFrameworkCore;
using Test4.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Test4.DbMigrator;

[DependsOn(
    typeof(Test4SharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class Test4DbMigratorModule : AbpModule
{

}

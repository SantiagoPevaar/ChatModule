using Test5.AdministrationService;
using Test5.AdministrationService.EntityFrameworkCore;
using Test5.ChatService;
using Test5.ChatService.EntityFrameworkCore;
using Test5.IdentityService;
using Test5.IdentityService.EntityFrameworkCore;
using Test5.ProductService;
using Test5.ProductService.EntityFrameworkCore;
using Test5.SaasService;
using Test5.SaasService.EntityFrameworkCore;
using Test5.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Test5.DbMigrator;

[DependsOn(
    typeof(Test5SharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule),
    typeof(ChatServiceApplicationContractsModule),
    typeof(ChatServiceEntityFrameworkCoreModule)
)]
public class Test5DbMigratorModule : AbpModule
{

}

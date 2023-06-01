using System;
using Microsoft.Extensions.Logging;
using Test3.SaasService.EntityFrameworkCore;
using Test3.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Test3.SaasService.DbMigrations;

public class SaasServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<SaasServiceDbContext>
{
    public SaasServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock) : base(
        loggerFactory,
        unitOfWorkManager,
        serviceProvider,
        currentTenant,
        distributedEventBus,
        abpDistributedLock,
        SaasServiceDbProperties.ConnectionStringName)
    {
    }
}

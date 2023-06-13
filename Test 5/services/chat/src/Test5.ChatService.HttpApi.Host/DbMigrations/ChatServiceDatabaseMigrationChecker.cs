using System;
using Microsoft.Extensions.Logging;
using Test5.ChatService.EntityFrameworkCore;
using Test5.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Test5.ChatService.DbMigrations;

public class ChatServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<ChatServiceDbContext>
{
    public ChatServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock)
        : base(
            loggerFactory,
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            ChatServiceDbProperties.ConnectionStringName)
    {

    }
}

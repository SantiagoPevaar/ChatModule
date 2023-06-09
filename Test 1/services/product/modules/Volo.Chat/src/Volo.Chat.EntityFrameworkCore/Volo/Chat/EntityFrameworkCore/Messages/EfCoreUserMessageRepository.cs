﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Chat.Messages;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Volo.Chat.EntityFrameworkCore.Messages;

public class EfCoreUserMessageRepository : EfCoreRepository<IChatDbContext, UserMessage, Guid>, IUserMessageRepository
{
    public EfCoreUserMessageRepository(IDbContextProvider<IChatDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<MessageWithDetails>> GetMessagesAsync(Guid userId, Guid targetUserId, int skipCount, int maxResultCount, CancellationToken cancellationToken = default)
    {
        var query = from chatUserMessage in (await GetDbSetAsync())
                    join message in (await GetDbContextAsync()).ChatMessages on chatUserMessage.ChatMessageId equals message.Id
                    where userId == chatUserMessage.UserId && targetUserId == chatUserMessage.TargetUserId
                    select new MessageWithDetails
                    {
                        UserMessage = chatUserMessage,
                        Message = message
                    };

        return await query.OrderByDescending(x => x.Message.CreationTime).PageBy(skipCount, maxResultCount).ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<bool> HasConversationAsync(Guid userId, Guid targetUserId, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync()).AnyAsync(p => p.UserId == userId && p.TargetUserId == targetUserId, cancellationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Features;
using Volo.Abp.Uow;
using Volo.Abp.Users;
using Volo.Chat.Authorization;
using Volo.Chat.Messages;
using Volo.Chat.Users;

namespace Volo.Chat.Conversations;

[RequiresFeature(ChatFeatures.Enable)]
[Authorize(ChatPermissions.Messaging)]
public class ConversationAppService : ChatAppService, IConversationAppService
{
    private readonly MessagingManager _messagingManager;
    private readonly IChatUserLookupService _chatUserLookupService;
    private readonly IConversationRepository _conversationRepository;
    private readonly IRealTimeChatMessageSender _realTimeChatMessageSender;
    private readonly IAuthorizationService _authorizationService;

    public ConversationAppService(
        MessagingManager messagingManager,
        IChatUserLookupService chatUserLookupService,
        IConversationRepository conversationRepository,
        IRealTimeChatMessageSender realTimeChatMessageSender,
        IAuthorizationService authorizationService)
    {
        _messagingManager = messagingManager;
        _chatUserLookupService = chatUserLookupService;
        _conversationRepository = conversationRepository;
        _realTimeChatMessageSender = realTimeChatMessageSender;
        _authorizationService = authorizationService;
    }

    public virtual async Task SendMessageAsync(SendMessageInput input)
    {
        var targetUser = await _chatUserLookupService.FindByIdAsync(input.TargetUserId);
        if (targetUser == null)
        {
            throw new BusinessException("Volo.Chat:010002");
        }

        var hasGrantToStartConversation = await _authorizationService.IsGrantedAsync(ChatPermissions.Searching);
        if (!hasGrantToStartConversation)
        {
            var hasConversation = await _messagingManager.HasConversationAsync(targetUser.Id);
            if (!hasConversation)
            {
                throw new AbpAuthorizationException(code: AbpAuthorizationErrorCodes.GivenRequirementHasNotGrantedForGivenResource);
            }
        }

        using (var uow = UnitOfWorkManager.Begin(requiresNew: true))
        {
            await _messagingManager.CreateNewMessage(
                CurrentUser.GetId(),
                targetUser.Id,
                input.Message
            );

            await uow.CompleteAsync();
        }

        var senderUser = await _chatUserLookupService.FindByIdAsync(CurrentUser.GetId());
        await _realTimeChatMessageSender.SendAsync(
            targetUser.Id,
            new ChatMessageRdto
            {
                SenderName = senderUser.Name,
                SenderSurname = senderUser.Surname,
                SenderUserId = senderUser.Id,
                SenderUsername = senderUser.UserName,
                Text = input.Message
            }
        );
    }

    public virtual async Task<ChatConversationDto> GetConversationAsync(GetConversationInput input)
    {
        var targetUser = await _chatUserLookupService.FindByIdAsync(input.TargetUserId);
        if (targetUser == null)
        {
            throw new BusinessException("Volo.Chat:010003");
        }

        var chatConversation = new ChatConversationDto
        {
            TargetUserInfo = new ChatTargetUserInfo
            {
                UserId = targetUser.Id,
                Name = targetUser.Name,
                Surname = targetUser.Surname,
                Username = targetUser.UserName,
            },
            Messages = new List<ChatMessageDto>()
        };

        var messages = await _messagingManager.ReadMessagesAsync(targetUser.Id, input.SkipCount, input.MaxResultCount);

        chatConversation.Messages.AddRange(
            messages.Select(x => new ChatMessageDto
            {
                Message = x.Message.Text,
                MessageDate = x.Message.CreationTime,
                ReadDate = x.Message.ReadTime ?? DateTime.MaxValue,
                IsRead = x.Message.IsAllRead,
                Side = x.UserMessage.Side
            })
            );


        return chatConversation;
    }

    public virtual async Task MarkConversationAsReadAsync(MarkConversationAsReadInput input)
    {
        var conversationPair = await _conversationRepository.FindPairAsync(CurrentUser.GetId(), input.TargetUserId);

        if (conversationPair.SenderConversation.LastMessageSide == ChatMessageSide.Receiver)
        {
            conversationPair.SenderConversation.ResetUnreadMessageCount();
            await _conversationRepository.UpdateAsync(conversationPair.SenderConversation);
        }
    }
}

﻿using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Chat.Localization;

namespace Volo.Chat.Authorization;

public class ChatPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var group = context.AddGroup(ChatPermissions.GroupName, L("Permission:Chat"));
        group.AddPermission(ChatPermissions.Messaging, L("Permission:Messaging"))
            .RequireFeatures(ChatFeatures.Enable);

        group.AddPermission(ChatPermissions.Searching, L("Permission:Searching"))
            .RequireFeatures(ChatFeatures.Enable);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ChatResource>(name);
    }
}

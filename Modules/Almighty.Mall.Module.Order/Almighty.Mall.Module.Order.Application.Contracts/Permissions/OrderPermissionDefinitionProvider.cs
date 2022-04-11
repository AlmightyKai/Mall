﻿using Almighty.Mall.Module.Order.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Almighty.Mall.Module.Order.Permissions;

public class OrderPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OrderPermissions.GroupName, L("Permission:Order"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OrderResource>(name);
    }
}

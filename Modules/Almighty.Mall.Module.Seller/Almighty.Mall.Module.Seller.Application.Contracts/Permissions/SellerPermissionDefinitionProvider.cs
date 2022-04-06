using Almighty.Mall.Module.Seller.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Almighty.Mall.Module.Seller.Permissions;

public class SellerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SellerPermissions.GroupName, L("Permission:Seller"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SellerResource>(name);
    }
}

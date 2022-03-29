using Kai.Mall.Module.Product.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Kai.Mall.Module.Product.Permissions
{
    public class PermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(Permissions.GroupName, L("Permission:Product"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductResource>(name);
        }
    }
}

using Almighty.Mall.Module.Product.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Almighty.Mall.Module.Product.Permissions
{
    public class PermissionDefinitionProvider : Volo.Abp.Authorization.Permissions.PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            PermissionGroupDefinition group = context.AddGroup(Permissions.GroupName, L("Permission:Product"));

            PermissionDefinition attributes = group.AddPermission(Permissions.Attributes.Default, L("Permission:Product.Attribute"));
            attributes.AddChild(Permissions.Attributes.Create, L("Permission:Product.Attribute.Create"));
            attributes.AddChild(Permissions.Attributes.Update, L("Permission:Product.Attribute.Edit"));
            attributes.AddChild(Permissions.Attributes.Delete, L("Permission:Product.Attribute.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductResource>(name);
        }
    }
}

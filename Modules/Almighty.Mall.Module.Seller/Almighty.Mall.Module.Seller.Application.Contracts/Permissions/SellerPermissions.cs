using Volo.Abp.Reflection;

namespace Almighty.Mall.Module.Seller.Permissions;

public class SellerPermissions
{
    public const string GroupName = "Seller";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SellerPermissions));
    }
}

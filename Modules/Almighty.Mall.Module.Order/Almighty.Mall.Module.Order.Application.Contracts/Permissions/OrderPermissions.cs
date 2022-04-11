using Volo.Abp.Reflection;

namespace Almighty.Mall.Module.Order.Permissions;

public class OrderPermissions
{
    public const string GroupName = "Order";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrderPermissions));
    }
}

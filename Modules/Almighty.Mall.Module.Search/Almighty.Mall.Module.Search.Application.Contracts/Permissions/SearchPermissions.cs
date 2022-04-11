using Volo.Abp.Reflection;

namespace Almighty.Mall.Module.Search.Permissions;

public class SearchPermissions
{
    public const string GroupName = "Search";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SearchPermissions));
    }
}

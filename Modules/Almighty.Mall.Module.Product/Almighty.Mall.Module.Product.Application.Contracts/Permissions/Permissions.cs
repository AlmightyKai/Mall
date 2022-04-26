using Volo.Abp.Reflection;

namespace Almighty.Mall.Module.Product.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    public class Permissions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string GroupName = "Product";

        /// <summary>
        /// 
        /// </summary>
        public static class Attributes
        {
            public const string Default = $"{Permissions.GroupName}.{nameof(Permissions.Attributes)}";

            public const string Create  = $"{Permissions.Attributes.Default}.{nameof(Permissions.Attributes.Create)}";
            public const string Update  = $"{Permissions.Attributes.Default}.{nameof(Permissions.Attributes.Update)}";
            public const string Delete  = $"{Permissions.Attributes.Default}.{nameof(Permissions.Attributes.Delete)}";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Permissions));
        }
    }
}

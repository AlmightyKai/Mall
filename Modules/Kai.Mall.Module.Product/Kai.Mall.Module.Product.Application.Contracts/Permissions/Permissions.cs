﻿using Volo.Abp.Reflection;

namespace Kai.Mall.Module.Product.Permissions
{
    public class Permissions
    {
        public const string GroupName = "Product";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Permissions));
        }
    }
}

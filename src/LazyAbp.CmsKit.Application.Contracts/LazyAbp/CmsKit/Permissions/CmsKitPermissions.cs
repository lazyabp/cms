using Volo.Abp.Reflection;

namespace LazyAbp.CmsKit.Permissions
{
    public class CmsKitPermissions
    {
        public const string GroupName = "CmsKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsKitPermissions));
        }

        public class UserCategory
        {
            public const string Default = GroupName + ".UserCategory";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}

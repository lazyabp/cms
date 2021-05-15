using Volo.Abp.Reflection;

namespace Lazy.Abp.Cms.Permissions
{
    public class CmsPermissions
    {
        public const string GroupName = "Cms";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsPermissions));
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

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace LazyAbp.CmsKit.Admin.Permissions
{
    public class CmsKitAdminPermissions
    {
        public const string GroupName = "CmsKit.Admin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsKitAdminPermissions));
        }

        public class Article
        {
            public const string Default = GroupName + ".Article";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Audit = Default + ".Audit";
        }

        public class Category
        {
            public const string Default = GroupName + ".Category";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class SinglePage
        {
            public const string Default = GroupName + ".SinglePage";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Tag
        {
            public const string Default = GroupName + ".Tag";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}

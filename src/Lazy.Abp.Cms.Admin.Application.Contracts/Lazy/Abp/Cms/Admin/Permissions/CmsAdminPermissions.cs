using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Lazy.Abp.Cms.Admin.Permissions
{
    public class CmsAdminPermissions
    {
        public const string GroupName = "Cms.Admin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsAdminPermissions));
        }

        public class Article
        {
            public const string Default = GroupName + ".Article";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Audit = Default + ".Audit";
        }

        public class ArticleSale
        {
            public const string Default = GroupName + ".ArticleSale";
            public const string Delete = Default + ".Delete";
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

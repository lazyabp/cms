using LazyAbp.CmsKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyAbp.CmsKit.Admin.Permissions
{
    public class CmsKitAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CmsKitAdminPermissions.GroupName, L("Permission:CmsKitAdmin"));

            var articlePermission = myGroup.AddPermission(CmsKitAdminPermissions.Article.Default, L("Permission:Article"));
            articlePermission.AddChild(CmsKitAdminPermissions.Article.Create, L("Permission:Create"));
            articlePermission.AddChild(CmsKitAdminPermissions.Article.Update, L("Permission:Update"));
            articlePermission.AddChild(CmsKitAdminPermissions.Article.Delete, L("Permission:Delete"));
            articlePermission.AddChild(CmsKitAdminPermissions.Article.Audit, L("Permission:Audit"));

            var categoryPermission = myGroup.AddPermission(CmsKitAdminPermissions.Category.Default, L("Permission:Category"));
            categoryPermission.AddChild(CmsKitAdminPermissions.Category.Create, L("Permission:Create"));
            categoryPermission.AddChild(CmsKitAdminPermissions.Category.Update, L("Permission:Update"));
            categoryPermission.AddChild(CmsKitAdminPermissions.Category.Delete, L("Permission:Delete"));

            var singlePagePermission = myGroup.AddPermission(CmsKitAdminPermissions.SinglePage.Default, L("Permission:SinglePage"));
            singlePagePermission.AddChild(CmsKitAdminPermissions.SinglePage.Create, L("Permission:Create"));
            singlePagePermission.AddChild(CmsKitAdminPermissions.SinglePage.Update, L("Permission:Update"));
            singlePagePermission.AddChild(CmsKitAdminPermissions.SinglePage.Delete, L("Permission:Delete"));

            var tagPermission = myGroup.AddPermission(CmsKitAdminPermissions.Tag.Default, L("Permission:Tag"));
            tagPermission.AddChild(CmsKitAdminPermissions.Tag.Create, L("Permission:Create"));
            tagPermission.AddChild(CmsKitAdminPermissions.Tag.Update, L("Permission:Update"));
            tagPermission.AddChild(CmsKitAdminPermissions.Tag.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitResource>(name);
        }
    }
}

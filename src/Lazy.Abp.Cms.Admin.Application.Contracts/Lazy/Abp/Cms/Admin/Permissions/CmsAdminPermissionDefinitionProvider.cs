using Lazy.Abp.Cms.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.Cms.Admin.Permissions
{
    public class CmsAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CmsAdminPermissions.GroupName, L("Permission:CmsAdmin"));

            var articlePermission = myGroup.AddPermission(CmsAdminPermissions.Article.Default, L("Permission:Article"));
            articlePermission.AddChild(CmsAdminPermissions.Article.Create, L("Permission:Create"));
            articlePermission.AddChild(CmsAdminPermissions.Article.Update, L("Permission:Update"));
            articlePermission.AddChild(CmsAdminPermissions.Article.Delete, L("Permission:Delete"));
            articlePermission.AddChild(CmsAdminPermissions.Article.Audit, L("Permission:Audit"));

            var articleSalePermission = myGroup.AddPermission(CmsAdminPermissions.ArticleSale.Default, L("Permission:ArticleSale"));
            articleSalePermission.AddChild(CmsAdminPermissions.ArticleSale.Delete, L("Permission:Delete"));

            var categoryPermission = myGroup.AddPermission(CmsAdminPermissions.Category.Default, L("Permission:Category"));
            categoryPermission.AddChild(CmsAdminPermissions.Category.Create, L("Permission:Create"));
            categoryPermission.AddChild(CmsAdminPermissions.Category.Update, L("Permission:Update"));
            categoryPermission.AddChild(CmsAdminPermissions.Category.Delete, L("Permission:Delete"));

            var singlePagePermission = myGroup.AddPermission(CmsAdminPermissions.SinglePage.Default, L("Permission:SinglePage"));
            singlePagePermission.AddChild(CmsAdminPermissions.SinglePage.Create, L("Permission:Create"));
            singlePagePermission.AddChild(CmsAdminPermissions.SinglePage.Update, L("Permission:Update"));
            singlePagePermission.AddChild(CmsAdminPermissions.SinglePage.Delete, L("Permission:Delete"));

            var tagPermission = myGroup.AddPermission(CmsAdminPermissions.Tag.Default, L("Permission:Tag"));
            tagPermission.AddChild(CmsAdminPermissions.Tag.Create, L("Permission:Create"));
            tagPermission.AddChild(CmsAdminPermissions.Tag.Update, L("Permission:Update"));
            tagPermission.AddChild(CmsAdminPermissions.Tag.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsResource>(name);
        }
    }
}

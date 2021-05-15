using Lazy.Abp.Cms.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.Cms.Permissions
{
    public class CmsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CmsPermissions.GroupName, L("Permission:Cms"));

            var userCategoryPermission = myGroup.AddPermission(CmsPermissions.UserCategory.Default, L("Permission:UserCategory"));
            userCategoryPermission.AddChild(CmsPermissions.UserCategory.Create, L("Permission:Create"));
            userCategoryPermission.AddChild(CmsPermissions.UserCategory.Update, L("Permission:Update"));
            userCategoryPermission.AddChild(CmsPermissions.UserCategory.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsResource>(name);
        }
    }
}

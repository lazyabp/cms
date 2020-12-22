using LazyAbp.CmsKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyAbp.CmsKit.Permissions
{
    public class CmsKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CmsKitPermissions.GroupName, L("Permission:CmsKit"));

            var userCategoryPermission = myGroup.AddPermission(CmsKitPermissions.UserCategory.Default, L("Permission:UserCategory"));
            userCategoryPermission.AddChild(CmsKitPermissions.UserCategory.Create, L("Permission:Create"));
            userCategoryPermission.AddChild(CmsKitPermissions.UserCategory.Update, L("Permission:Update"));
            userCategoryPermission.AddChild(CmsKitPermissions.UserCategory.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsKitResource>(name);
        }
    }
}

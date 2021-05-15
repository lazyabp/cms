using System.Threading.Tasks;
using Lazy.Abp.Cms.Localization;
using Lazy.Abp.Cms.Permissions;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.Cms.Web.Menus
{
    public class CmsMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<CmsResource>();
            //Add main menu items.
        }
    }
}

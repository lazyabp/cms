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

            var menu = new ApplicationMenuItem("DefaultMenu", l["Menu:Cms"]);

            context.Menu.AddItem(menu);


            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.ArticleLike, l["Menu:ArticleLike"], "/Cms/ArticleLike")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.Article, l["Menu:Article"], "/Cms/Article")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.ArticleFavorite, l["Menu:ArticleFavorite"], "/Cms/ArticleFavorite")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.ArticleSale, l["Menu:ArticleSale"], "/Cms/ArticleSale")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.Category, l["Menu:Category"], "/Cms/Category")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.SinglePage, l["Menu:SinglePage"], "/Cms/SinglePage")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsMenus.Tag, l["Menu:Tag"], "/Cms/Tag")
            );

            if (await context.IsGrantedAsync(CmsPermissions.UserCategory.Default))
            {
                menu.AddItem(
                    new ApplicationMenuItem(CmsMenus.UserCategory, l["Menu:UserCategory"], "/Cms/UserCategory")
                );
            }
        }
    }
}

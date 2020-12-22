using System.Threading.Tasks;
using LazyAbp.CmsKit.Localization;
using LazyAbp.CmsKit.Permissions;
using Volo.Abp.UI.Navigation;

namespace LazyAbp.CmsKit.Web.Menus
{
    public class CmsKitMenuContributor : IMenuContributor
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
            var l = context.GetLocalizer<CmsKitResource>();
            //Add main menu items.

            var menu = new ApplicationMenuItem("DefaultMenu", l["Menu:Cms"]);

            context.Menu.AddItem(menu);


            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.ArticleLike, l["Menu:ArticleLike"], "/CmsKit/ArticleLike")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.Article, l["Menu:Article"], "/CmsKit/Article")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.ArticleFavorite, l["Menu:ArticleFavorite"], "/CmsKit/ArticleFavorite")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.ArticleSale, l["Menu:ArticleSale"], "/CmsKit/ArticleSale")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.Category, l["Menu:Category"], "/CmsKit/Category")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.SinglePage, l["Menu:SinglePage"], "/CmsKit/SinglePage")
            );

            menu.AddItem(
                new ApplicationMenuItem(CmsKitMenus.Tag, l["Menu:Tag"], "/CmsKit/Tag")
            );

            if (await context.IsGrantedAsync(CmsKitPermissions.UserCategory.Default))
            {
                menu.AddItem(
                    new ApplicationMenuItem(CmsKitMenus.UserCategory, l["Menu:UserCategory"], "/CmsKit/UserCategory")
                );
            }
        }
    }
}

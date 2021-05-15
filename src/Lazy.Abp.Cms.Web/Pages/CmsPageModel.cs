using Lazy.Abp.Cms.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.Cms.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CmsPageModel : AbpPageModel
    {
        protected CmsPageModel()
        {
            LocalizationResourceType = typeof(CmsResource);
            ObjectMapperContext = typeof(CmsWebModule);
        }
    }
}
using Lazy.Abp.Cms.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms
{
    public abstract class CmsAppService : ApplicationService
    {
        protected CmsAppService()
        {
            LocalizationResource = typeof(CmsResource);
            ObjectMapperContext = typeof(CmsApplicationModule);
        }
    }
}

using LazyAbp.CmsKit.Localization;
using Volo.Abp.Application.Services;

namespace LazyAbp.CmsKit
{
    public abstract class CmsKitAppService : ApplicationService
    {
        protected CmsKitAppService()
        {
            LocalizationResource = typeof(CmsKitResource);
            ObjectMapperContext = typeof(CmsKitApplicationModule);
        }
    }
}

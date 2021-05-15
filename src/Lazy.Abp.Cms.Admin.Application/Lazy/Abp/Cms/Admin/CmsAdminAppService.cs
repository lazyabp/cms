using Lazy.Abp.Cms.Localization;
using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin
{
    public class CmsAdminAppService : ApplicationService
    {
        protected CmsAdminAppService()
        {
            ObjectMapperContext = typeof(CmsAdminApplicationModule);
            LocalizationResource = typeof(CmsResource);
        }
    }
}

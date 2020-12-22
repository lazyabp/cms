using LazyAbp.CmsKit.Localization;
using System;
using Volo.Abp.Application.Services;

namespace LazyAbp.CmsKit.Admin
{
    public class CmsKitAdminAppService : ApplicationService
    {
        protected CmsKitAdminAppService()
        {
            ObjectMapperContext = typeof(CmsKitAdminApplicationModule);
            LocalizationResource = typeof(CmsKitResource);
        }
    }
}

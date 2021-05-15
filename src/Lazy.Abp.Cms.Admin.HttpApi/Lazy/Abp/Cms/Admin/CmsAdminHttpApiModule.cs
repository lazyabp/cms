using Lazy.Abp.Cms.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Cms.Admin
{
    [DependsOn(
        typeof(CmsAdminApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CmsAdminHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CmsAdminHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CmsResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}

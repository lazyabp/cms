using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Cms.Admin
{
    [DependsOn(
        typeof(CmsAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CmsAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(CmsAdminApplicationContractsModule).Assembly,
                CmsAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace LazyAbp.CmsKit.Admin
{
    [DependsOn(
        typeof(CmsKitAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CmsKitAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(CmsKitAdminApplicationContractsModule).Assembly,
                CmsKitAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}

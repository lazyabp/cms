using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LazyAbp.CmsKit
{
    [DependsOn(
        typeof(CmsKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class CmsKitApplicationContractsModule : AbpModule
    {

    }
}

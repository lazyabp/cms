using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LazyAbp.CmsKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CmsKitDomainSharedModule)
    )]
    public class CmsKitDomainModule : AbpModule
    {

    }
}

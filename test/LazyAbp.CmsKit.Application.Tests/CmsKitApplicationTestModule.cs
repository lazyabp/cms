using Volo.Abp.Modularity;

namespace LazyAbp.CmsKit
{
    [DependsOn(
        typeof(CmsKitApplicationModule),
        typeof(CmsKitDomainTestModule)
        )]
    public class CmsKitApplicationTestModule : AbpModule
    {

    }
}

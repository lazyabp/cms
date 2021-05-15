using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Cms
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CmsDomainSharedModule)
    )]
    public class CmsDomainModule : AbpModule
    {

    }
}

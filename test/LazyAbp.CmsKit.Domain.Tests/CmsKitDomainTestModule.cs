using LazyAbp.CmsKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.CmsKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CmsKitEntityFrameworkCoreTestModule)
        )]
    public class CmsKitDomainTestModule : AbpModule
    {
        
    }
}

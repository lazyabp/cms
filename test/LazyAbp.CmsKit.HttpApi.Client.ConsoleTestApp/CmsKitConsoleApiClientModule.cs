using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyAbp.CmsKit
{
    [DependsOn(
        typeof(CmsKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CmsKitConsoleApiClientModule : AbpModule
    {
        
    }
}

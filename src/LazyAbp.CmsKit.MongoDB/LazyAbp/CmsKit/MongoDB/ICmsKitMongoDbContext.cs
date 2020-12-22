using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.CmsKit.MongoDB
{
    [ConnectionStringName(CmsKitDbProperties.ConnectionStringName)]
    public interface ICmsKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}

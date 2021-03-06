using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Cms.MongoDB
{
    [ConnectionStringName(CmsDbProperties.ConnectionStringName)]
    public interface ICmsMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}

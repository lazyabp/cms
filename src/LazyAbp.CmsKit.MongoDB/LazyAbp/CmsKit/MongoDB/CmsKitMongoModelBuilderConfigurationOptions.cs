using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace LazyAbp.CmsKit.MongoDB
{
    public class CmsKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public CmsKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
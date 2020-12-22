using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyAbp.CmsKit.EntityFrameworkCore
{
    public class CmsKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CmsKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
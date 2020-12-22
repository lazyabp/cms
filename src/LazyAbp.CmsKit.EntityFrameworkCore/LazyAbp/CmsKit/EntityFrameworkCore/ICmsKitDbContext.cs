using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using LazyAbp.CmsKit;

namespace LazyAbp.CmsKit.EntityFrameworkCore
{
    [ConnectionStringName(CmsKitDbProperties.ConnectionStringName)]
    public interface ICmsKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Article> Articles { get; set; }
        DbSet<ArticleComment> ArticleComments { get; set; }
        DbSet<ArticlePicture> ArticlePictures { get; set; }
        DbSet<ArticleContent> ArticleContents { get; set; }
        DbSet<ArticleFavorite> ArticleFavorites { get; set; }
        DbSet<ArticleLike> ArticleLikes { get; set; }
        DbSet<ArticleMeta> ArticleMetas { get; set; }
        DbSet<ArticleSale> ArticleSales { get; set; }
        DbSet<ArticleCategory> ArticleCategories { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<SinglePage> SinglePages { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ArticleTag> ArticleTags { get; set; }
        DbSet<UserCategory> UserCategories { get; set; }
        DbSet<ArticleAuditLog> ArticleAuditLogs { get; set; }
    }
}

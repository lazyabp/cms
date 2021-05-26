using Lazy.Abp.Cms.ArticleAuditLogs;
using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleLikes;
using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.ArticleSales;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.Tags;
using Lazy.Abp.Cms.UserCategories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Cms.EntityFrameworkCore
{
    [ConnectionStringName(CmsDbProperties.ConnectionStringName)]
    public interface ICmsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Article> Articles { get; set; }
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

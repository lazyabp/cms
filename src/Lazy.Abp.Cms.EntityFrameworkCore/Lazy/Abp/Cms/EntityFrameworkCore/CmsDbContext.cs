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
    public class CmsDbContext : AbpDbContext<CmsDbContext>, ICmsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlePicture> ArticlePictures { get; set; }
        public DbSet<ArticleContent> ArticleContents { get; set; }
        public DbSet<ArticleFavorite> ArticleFavorites { get; set; }
        public DbSet<ArticleLike> ArticleLikes { get; set; }
        public DbSet<ArticleMeta> ArticleMetas { get; set; }
        public DbSet<ArticleSale> ArticleSales { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SinglePage> SinglePages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<ArticleAuditLog> ArticleAuditLogs { get; set; }

        public CmsDbContext(DbContextOptions<CmsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCms();
        }
    }
}

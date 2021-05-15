using Lazy.Abp.Cms;
using Lazy.Abp.Cms.ArticleAuditLogs;
using Lazy.Abp.Cms.ArticleComments;
using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleLikes;
using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.ArticleSales;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.Tags;
using Lazy.Abp.Cms.UserCategories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Cms.EntityFrameworkCore
{
    [DependsOn(
        typeof(CmsDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CmsEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CmsDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Article, ArticleRepository>();
                options.AddRepository<ArticleComment, ArticleCommentRepository>();
                options.AddRepository<ArticleContent, ArticleContentRepository>();
                options.AddRepository<ArticleFavorite, ArticleFavoriteRepository>();
                options.AddRepository<ArticleLike, ArticleLikeRepository>();
                options.AddRepository<ArticleSale, ArticleSaleRepository>();
                options.AddRepository<Category, CategoryRepository>();
                //options.AddRepository<ArticleCategory, ArticleCategoryRepository>();
                options.AddRepository<SinglePage, SinglePageRepository>();
                options.AddRepository<Tag, TagRepository>();
                //options.AddRepository<ArticleTag, ArticleTagRepository>();
                options.AddRepository<UserCategory, UserCategoryRepository>();
                options.AddRepository<ArticleAuditLog, ArticleAuditLogRepository>();
            });
        }
    }
}

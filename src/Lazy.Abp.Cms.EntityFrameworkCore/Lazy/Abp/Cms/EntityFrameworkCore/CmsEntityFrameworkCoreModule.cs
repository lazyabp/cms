using Lazy.Abp.Cms;
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
                options.AddRepository<ArticleCategory, ArticleCategoryRepository>();
                options.AddRepository<SinglePage, SinglePageRepository>();
                options.AddRepository<Tag, TagRepository>();
                options.AddRepository<ArticleTag, ArticleTagRepository>();
                options.AddRepository<UserCategory, UserCategoryRepository>();
                options.AddRepository<ArticleAuditLog, ArticleAuditLogRepository>();
            });
        }
    }
}

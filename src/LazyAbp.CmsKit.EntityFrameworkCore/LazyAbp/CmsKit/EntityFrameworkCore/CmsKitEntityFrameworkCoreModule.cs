using LazyAbp.CmsKit;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.CmsKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(CmsKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CmsKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CmsKitDbContext>(options =>
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

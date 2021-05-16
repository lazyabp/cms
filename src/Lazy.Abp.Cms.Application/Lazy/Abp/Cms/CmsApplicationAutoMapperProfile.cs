using AutoMapper;
using Lazy.Abp.Cms.ArticleAuditLogs;
using Lazy.Abp.Cms.ArticleAuditLogs.Dtos;
using Lazy.Abp.Cms.ArticleComments;
using Lazy.Abp.Cms.ArticleComments.Dtos;
using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleFavorites.Dtos;
using Lazy.Abp.Cms.ArticleLikes;
using Lazy.Abp.Cms.ArticleLikes.Dtos;
using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.Articles.Dtos;
using Lazy.Abp.Cms.ArticleSales;
using Lazy.Abp.Cms.ArticleSales.Dtos;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.Categories.Dtos;
using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.SinglePages.Dtos;
using Lazy.Abp.Cms.Tags;
using Lazy.Abp.Cms.Tags.Dtos;
using Lazy.Abp.Cms.UserCategories;
using Lazy.Abp.Cms.UserCategories.Dtos;

namespace Lazy.Abp.Cms
{
    public class CmsApplicationAutoMapperProfile : Profile
    {
        public CmsApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleComment, ArticleCommentDto>();
            CreateMap<ArticleCommentCreateUpdateDto, ArticleComment>(MemberList.Source);

            CreateMap<ArticleMeta, ArticleMetaDto>();
            CreateMap<ArticleContent, ArticleContentDto>();
            CreateMap<ArticlePicture, ArticlePictureDto>();

            CreateMap<ArticleFavorite, ArticleFavoriteDto>();

            CreateMap<ArticleLike, ArticleLikeDto>();

            CreateMap<ArticleSale, ArticleSaleDto>();
            CreateMap<ArticleSaleCreateUpdateDto, ArticleSale>(MemberList.Source);

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryViewDto>();

            CreateMap<ArticleCategory, ArticleCategoryDto>();

            CreateMap<SinglePage, SinglePageDto>();

            CreateMap<Tag, TagDto>();

            CreateMap<ArticleTag, ArticleTagDto>();

            CreateMap<UserCategory, UserCategoryDto>();
            CreateMap<UserCategoryCreateUpdateDto, UserCategory>(MemberList.Source);

            CreateMap<ArticleAuditLog, ArticleAuditLogDto>();
        }
    }
}

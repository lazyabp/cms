using LazyAbp.CmsKit;
using LazyAbp.CmsKit.Dtos;
using AutoMapper;
using System.Text.Json;

namespace LazyAbp.CmsKit
{
    public class CmsKitApplicationAutoMapperProfile : Profile
    {
        public CmsKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Article, ArticleDto>();
            CreateMap<Article, ArticleViewDto>()
                .ForMember(q => q.Pictures, op => op.Ignore())
                .ForMember(q => q.Contents, op => op.Ignore())
                .ForMember(q => q.Categories, op => op.Ignore())
                .ForMember(q => q.Tags, op => op.Ignore());

            CreateMap<ArticleComment, ArticleCommentDto>();
            CreateMap<CreateUpdateArticleCommentDto, ArticleComment>(MemberList.Source);

            CreateMap<ArticlePicture, ArticlePictureDto>();

            CreateMap<ArticleContent, ArticleContentDto>();

            CreateMap<ArticleFavorite, ArticleFavoriteDto>();

            CreateMap<ArticleLike, ArticleLikeDto>();

            CreateMap<ArticleSale, ArticleSaleDto>();
            CreateMap<CreateUpdateArticleSaleDto, ArticleSale>(MemberList.Source);

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryViewDto>();

            CreateMap<ArticleCategory, ArticleCategoryDto>()
                .ForMember(q => q.Category, op => op.Ignore());

            CreateMap<SinglePage, SinglePageDto>();

            CreateMap<Tag, TagDto>();

            CreateMap<ArticleTag, ArticleTagDto>()
                .ForMember(q => q.Tag, op => op.Ignore());

            CreateMap<UserCategory, UserCategoryDto>();
            CreateMap<CreateUpdateUserCategoryDto, UserCategory>(MemberList.Source);

            CreateMap<ArticleAuditLog, ArticleAuditLogDto>();
        }
    }
}

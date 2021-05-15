using AutoMapper;
using Lazy.Abp.Cms.ArticleAuditLogs;
using Lazy.Abp.Cms.ArticleAuditLogs.Dtos;
using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleFavorites.Dtos;
using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.Articles.Dtos;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.Categories.Dtos;
using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.SinglePages.Dtos;
using Lazy.Abp.Cms.Tags;
using Lazy.Abp.Cms.Tags.Dtos;

namespace Lazy.Abp.Cms.Admin
{
    public class CmsAdminApplicationAutoMapperProfile : Profile
    {
        public CmsAdminApplicationAutoMapperProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleMeta, ArticleMetaDto>();
            CreateMap<ArticleContent, ArticleContentDto>();
            CreateMap<ArticleCategory, ArticleCategoryDto>(); 
            CreateMap<ArticleFavorite, ArticleFavoriteDto>();
            CreateMap<ArticleTag, ArticleTagDto>();
            CreateMap<ArticleAuditLog, ArticleAuditLogDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<SinglePage, SinglePageDto>();
            CreateMap<CreateUpdateSinglePageDto, SinglePage>(MemberList.Source);

            CreateMap<Tag, TagDto>();
            CreateMap<CreateUpdateTagDto, Tag>(MemberList.Source);
        }
    }
}

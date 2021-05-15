using AutoMapper;
using Lazy.Abp.Cms.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Cms.Admin
{
    public class CmsAdminApplicationAutoMapperProfile : Profile
    {
        public CmsAdminApplicationAutoMapperProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleContent, ArticleContentDto>();
            CreateMap<ArticleCategory, ArticleCategoryDto>(); 
            CreateMap<ArticleFavorite, ArticleFavoriteDto>();
            CreateMap<ArticleTag, ArticleTagDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<SinglePage, SinglePageDto>();
            CreateMap<CreateUpdateSinglePageDto, SinglePage>(MemberList.Source);

            CreateMap<Tag, TagDto>();
            CreateMap<CreateUpdateTagDto, Tag>(MemberList.Source);
        }
    }
}

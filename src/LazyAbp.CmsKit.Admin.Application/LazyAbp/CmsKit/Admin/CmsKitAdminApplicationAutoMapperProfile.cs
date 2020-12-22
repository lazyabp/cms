using AutoMapper;
using LazyAbp.CmsKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.CmsKit.Admin
{
    public class CmsKitAdminApplicationAutoMapperProfile : Profile
    {
        public CmsKitAdminApplicationAutoMapperProfile()
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

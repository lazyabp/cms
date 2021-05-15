using Lazy.Abp.Cms.Dtos;
using Lazy.Abp.Cms.Web.Pages.Cms.Article.ViewModels;
using Lazy.Abp.Cms.Web.Pages.Cms.UserCategory.ViewModels;
using AutoMapper;

namespace Lazy.Abp.Cms.Web
{
    public class CmsWebAutoMapperProfile : Profile
    {
        public CmsWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<ArticleDto, CreateEditArticleViewModel>();
            CreateMap<CreateEditArticleViewModel, CreateUpdateArticleDto>();
            CreateMap<UserCategoryDto, CreateEditUserCategoryViewModel>();
            CreateMap<CreateEditUserCategoryViewModel, CreateUpdateUserCategoryDto>();
        }
    }
}

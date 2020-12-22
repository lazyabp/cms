using LazyAbp.CmsKit.Dtos;
using LazyAbp.CmsKit.Web.Pages.CmsKit.Article.ViewModels;
using LazyAbp.CmsKit.Web.Pages.CmsKit.UserCategory.ViewModels;
using AutoMapper;

namespace LazyAbp.CmsKit.Web
{
    public class CmsKitWebAutoMapperProfile : Profile
    {
        public CmsKitWebAutoMapperProfile()
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

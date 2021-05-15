using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Cms;
using Lazy.Abp.Cms.Dtos;
using Lazy.Abp.Cms.Web.Pages.Cms.Article.ViewModels;

namespace Lazy.Abp.Cms.Web.Pages.Cms.Article
{
    public class CreateModalModel : CmsPageModel
    {
        [BindProperty]
        public CreateEditArticleViewModel ViewModel { get; set; }

        private readonly IArticleAppService _service;

        public CreateModalModel(IArticleAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditArticleViewModel, CreateUpdateArticleDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}
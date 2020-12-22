using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LazyAbp.CmsKit;
using LazyAbp.CmsKit.Dtos;
using LazyAbp.CmsKit.Web.Pages.CmsKit.Article.ViewModels;

namespace LazyAbp.CmsKit.Web.Pages.CmsKit.Article
{
    public class CreateModalModel : CmsKitPageModel
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
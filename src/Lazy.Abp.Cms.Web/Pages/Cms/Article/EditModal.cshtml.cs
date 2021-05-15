using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Cms;
using Lazy.Abp.Cms.Dtos;
using Lazy.Abp.Cms.Web.Pages.Cms.Article.ViewModels;

namespace Lazy.Abp.Cms.Web.Pages.Cms.Article
{
    public class EditModalModel : CmsPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditArticleViewModel ViewModel { get; set; }

        private readonly IArticleAppService _service;

        public EditModalModel(IArticleAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ArticleViewDto, CreateEditArticleViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditArticleViewModel, CreateUpdateArticleDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
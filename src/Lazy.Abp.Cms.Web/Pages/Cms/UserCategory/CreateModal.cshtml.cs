using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Cms;
using Lazy.Abp.Cms.Dtos;
using Lazy.Abp.Cms.Web.Pages.Cms.UserCategory.ViewModels;

namespace Lazy.Abp.Cms.Web.Pages.Cms.UserCategory
{
    public class CreateModalModel : CmsPageModel
    {
        [BindProperty]
        public CreateEditUserCategoryViewModel ViewModel { get; set; }

        private readonly IUserCategoryAppService _service;

        public CreateModalModel(IUserCategoryAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserCategoryViewModel, CreateUpdateUserCategoryDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}
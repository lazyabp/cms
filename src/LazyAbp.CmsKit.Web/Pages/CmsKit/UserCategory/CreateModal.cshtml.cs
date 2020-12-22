using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LazyAbp.CmsKit;
using LazyAbp.CmsKit.Dtos;
using LazyAbp.CmsKit.Web.Pages.CmsKit.UserCategory.ViewModels;

namespace LazyAbp.CmsKit.Web.Pages.CmsKit.UserCategory
{
    public class CreateModalModel : CmsKitPageModel
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
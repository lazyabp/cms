using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LazyAbp.CmsKit;
using LazyAbp.CmsKit.Dtos;
using LazyAbp.CmsKit.Web.Pages.CmsKit.UserCategory.ViewModels;

namespace LazyAbp.CmsKit.Web.Pages.CmsKit.UserCategory
{
    public class EditModalModel : CmsKitPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditUserCategoryViewModel ViewModel { get; set; }

        private readonly IUserCategoryAppService _service;

        public EditModalModel(IUserCategoryAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<UserCategoryDto, CreateEditUserCategoryViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditUserCategoryViewModel, CreateUpdateUserCategoryDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
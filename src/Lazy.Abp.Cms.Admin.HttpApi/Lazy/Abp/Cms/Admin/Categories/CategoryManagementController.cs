using Lazy.Abp.Cms.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms.Admin.Categories
{
    [RemoteService(Name = CmsAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cms")]
    [ControllerName("Category")]
    [Route("api/cms/categories/management")]
    public class CategoryManagementController : AbpController, ICategoryManagementAppService
    {
        private readonly ICategoryManagementAppService _service;

        public CategoryManagementController(ICategoryManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CategoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CategoryDto> CreateAsync(CategoryCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CategoryDto> UpdateAsync(Guid id, CategoryCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}

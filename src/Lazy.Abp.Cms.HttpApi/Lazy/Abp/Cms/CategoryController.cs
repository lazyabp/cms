using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms
{
    [RemoteService(Name = CmsRemoteServiceConsts.RemoteServiceName)]
    [Area("cms")]
    [ControllerName("Category")]
    [Route("api/cms/categories")]
    public class CategoryController : AbpController, ICategoryAppService
    {
        private readonly ICategoryAppService _service;

        public CategoryController(ICategoryAppService service)
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
        [Route("{id}/path")]
        public Task<List<CategoryViewDto>> GetPathAsync(Guid id)
        {
            return _service.GetPathAsync(id);
        }

        [HttpGet]
        [Route("by-parent-id/{id}")]
        public Task<List<CategoryViewDto>> GetByParentAsync(Guid? id)
        {
            return _service.GetByParentAsync(id);
        }

        [HttpGet]
        [Route("by-root-id/{id}")]
        public Task<List<CategoryViewDto>> GetByRootAsync(Guid? id)
        {
            return _service.GetByRootAsync(id);
        }

        [HttpGet]
        [Route("list/all")]
        public Task<ListResultDto<CategoryViewDto>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        public Task<PagedResultDto<CategoryViewDto>> GetListAsync(CategoryListRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}

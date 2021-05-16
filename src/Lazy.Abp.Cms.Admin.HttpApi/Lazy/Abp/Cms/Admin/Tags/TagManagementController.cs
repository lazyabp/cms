using Lazy.Abp.Cms.Tags.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms.Admin.Tags
{
    [RemoteService(Name = CmsAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cms")]
    [ControllerName("Tag")]
    [Route("api/cms/tags/management")]
    public class TagManagementController : AbpController, ITagManagementAppService
    {
        private readonly ITagManagementAppService _service;

        public TagManagementController(ITagManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<TagDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<TagDto>> GetListAsync(TagListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<TagDto> CreateAsync(TagCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<TagDto> UpdateAsync(Guid id, TagCreateUpdateDto input)
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

using Lazy.Abp.Cms.Tags;
using Lazy.Abp.Cms.Tags.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms
{
    [RemoteService(Name = CmsRemoteServiceConsts.RemoteServiceName)]
    [Area("cms")]
    [ControllerName("Tag")]
    [Route("api/cms/tags")]
    public class TagController : AbpController, ITagAppService
    {
        private readonly ITagAppService _service;

        public TagController(ITagAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedResultDto<TagDto>> GetListAsync(TagListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}/hits")]
        public Task<int> IncHits(Guid id)
        {
            return _service.IncHits(id);
        }
    }
}

using LazyAbp.CmsKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.CmsKit
{
    [RemoteService(Name = CmsKitRemoteServiceConsts.RemoteServiceName)]
    [Area("cmskit")]
    [ControllerName("Tag")]
    [Route("api/cmskit/tags")]
    public class TagController : AbpController, ITagAppService
    {
        private readonly ITagAppService _service;

        public TagController(ITagAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedResultDto<TagDto>> GetListAsync(GetTagListRequestDto input)
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

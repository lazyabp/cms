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
    [ControllerName("SinglePage")]
    [Route("api/cmskit/single-pages")]
    public class SinglePageController : AbpController, ISinglePageAppService
    {
        private readonly ISinglePageAppService _service;

        public SinglePageController(ISinglePageAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<SinglePageDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("by-name/{name}")]
        public Task<SinglePageDto> GetByName(string name)
        {
            return _service.GetByName(name);
        }

        [HttpGet]
        public Task<PagedResultDto<SinglePageDto>> GetListAsync(GetSinglePageListRequestDto input)
        {
            return _service.GetListAsync(input);
        }
    }
}

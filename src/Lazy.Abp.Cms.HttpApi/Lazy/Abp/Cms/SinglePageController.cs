using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.SinglePages.Dtos;
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
    [ControllerName("SinglePage")]
    [Route("api/cms/single-pages")]
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

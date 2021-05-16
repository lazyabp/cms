using Lazy.Abp.Cms.SinglePages.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms.Admin.SinglePages
{
    [RemoteService(Name = CmsAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cms")]
    [ControllerName("SinglePage")]
    [Route("api/cms/single-pages/management")]
    public class SinglePageManagementController : AbpController, ISinglePageManagementAppService
    {
        private readonly ISinglePageManagementAppService _service;

        public SinglePageManagementController(ISinglePageManagementAppService service)
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
        public Task<PagedResultDto<SinglePageDto>> GetListAsync(SinglePageListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<SinglePageDto> CreateAsync(SinglePageCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<SinglePageDto> UpdateAsync(Guid id, SinglePageCreateUpdateDto input)
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

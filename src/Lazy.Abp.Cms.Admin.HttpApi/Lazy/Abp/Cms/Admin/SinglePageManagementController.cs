using Lazy.Abp.Cms.SinglePages.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms.Admin
{
    [RemoteService(Name = CmsAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cmsadmin")]
    [ControllerName("SinglePage")]
    [Route("api/cms/single-pages/admin")]
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
        public Task<PagedResultDto<SinglePageDto>> GetListAsync(GetSinglePageListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<SinglePageDto> CreateAsync(CreateUpdateSinglePageDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<SinglePageDto> UpdateAsync(Guid id, CreateUpdateSinglePageDto input)
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

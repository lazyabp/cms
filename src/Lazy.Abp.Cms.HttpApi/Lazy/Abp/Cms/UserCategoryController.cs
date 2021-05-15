using Lazy.Abp.Cms.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms
{
    [RemoteService(Name = CmsRemoteServiceConsts.RemoteServiceName)]
    [Area("cmskit")]
    [ControllerName("UserCategory")]
    [Route("api/cmskit/user-categories")]
    public class UserCategoryController : AbpController, IUserCategoryAppService
    {
        private readonly IUserCategoryAppService _service;

        public UserCategoryController(IUserCategoryAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserCategoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<UserCategoryDto>> GetListAsync(GetUserCategoryListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<UserCategoryDto> CreateAsync(CreateUpdateUserCategoryDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<UserCategoryDto> UpdateAsync(Guid id, CreateUpdateUserCategoryDto input)
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

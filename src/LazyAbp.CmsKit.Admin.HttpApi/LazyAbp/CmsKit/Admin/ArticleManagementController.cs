using LazyAbp.CmsKit.Admin;
using LazyAbp.CmsKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.CmsKit.Admin
{
    [RemoteService(Name = CmsKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cmskitadmin")]
    [ControllerName("Article")]
    [Route("api/cmskit/articles/admin")]
    public class ArticleManagementController : AbpController, IArticleManagementAppService
    {
        private readonly IArticleManagementAppService _service;

        public ArticleManagementController(IArticleManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleViewDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/set-active")]
        public Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            return _service.SetActiveAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/audit")]
        public Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input)
        {
            return _service.AuditAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}

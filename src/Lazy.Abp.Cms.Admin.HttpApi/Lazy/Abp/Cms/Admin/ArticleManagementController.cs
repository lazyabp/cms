﻿using Lazy.Abp.Cms.ArticleAuditLogs.Dtos;
using Lazy.Abp.Cms.Articles.Dtos;
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
    [ControllerName("Article")]
    [Route("api/cms/articles/admin")]
    public class ArticleManagementController : AbpController, IArticleManagementAppService
    {
        private readonly IArticleManagementAppService _service;

        public ArticleManagementController(IArticleManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleDto>> GetListAsync(GetArticleListRequestDto input)
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

﻿using LazyAbp.CmsKit.Dtos;
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
    [ControllerName("Category")]
    [Route("api/cmskit/categories")]
    public class CategoryController : AbpController, ICategoryAppService
    {
        private readonly ICategoryAppService _service;

        public CategoryController(ICategoryAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CategoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("by-parent-id/{id}")]
        public Task<List<CategoryDto>> GetByParentAsync(Guid? id)
        {
            return _service.GetByParentAsync(id);
        }

        [HttpGet]
        [Route("by-root-id/{id}")]
        public Task<List<CategoryDto>> GetByRootAsync(Guid? id)
        {
            return _service.GetByRootAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}/path")]
        public Task<List<CategoryDto>> GetPathAsync(Guid id)
        {
            return _service.GetPathAsync(id);
        }
    }
}

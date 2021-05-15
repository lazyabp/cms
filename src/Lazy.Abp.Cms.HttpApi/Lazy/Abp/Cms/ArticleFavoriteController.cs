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
    [ControllerName("ArticleFavorite")]
    [Route("api/cmskit/article-favorites")]
    public class ArticleFavoriteController : AbpController, IArticleFavoriteAppService
    {
        private readonly IArticleFavoriteAppService _service;

        public ArticleFavoriteController(IArticleFavoriteAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleFavoriteDto>> GetListAsync(GetArticleFavoriteListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}

using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleFavorites.Dtos;
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
    [ControllerName("ArticleFavorite")]
    [Route("api/cms/article-favorites")]
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

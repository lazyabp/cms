using Lazy.Abp.Cms.ArticleSales;
using Lazy.Abp.Cms.ArticleSales.Dtos;
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
    [ControllerName("ArticleSale")]
    [Route("api/cms/article-sales")]
    public class ArticleSaleController : AbpController, IArticleSaleAppService
    {
        private readonly IArticleSaleAppService _service;

        public ArticleSaleController(IArticleSaleAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleSaleDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleSaleDto>> GetListAsync(GetArticleSalesListRequestDto input)
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

using Lazy.Abp.Cms.ArticleSales.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Cms.Admin.ArticleSales
{
    [RemoteService(Name = CmsAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cms")]
    [ControllerName("ArticleSale")]
    [Route("api/cms/article-sales/management")]
    public class ArticleSaleManagementController : AbpController, IArticleSaleManagementAppService
    {
        private readonly IArticleSaleManagementAppService _service;

        public ArticleSaleManagementController(IArticleSaleManagementAppService service)
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
        public Task<PagedResultDto<ArticleSaleDto>> GetListAsync(ArticleSalesListRequestDto input)
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

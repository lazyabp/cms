using Lazy.Abp.Cms.Admin.Permissions;
using Lazy.Abp.Cms.ArticleSales;
using Lazy.Abp.Cms.ArticleSales.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Lazy.Abp.Cms.Admin.ArticleSales
{
    public class ArticleSaleManagementAppService : CmsAdminAppService, IArticleSaleManagementAppService, ITransientDependency
    {
        private readonly IArticleSaleRepository _repository;
        
        public ArticleSaleManagementAppService(IArticleSaleRepository repository)
        {
            _repository = repository;
        }

        [Authorize(CmsAdminPermissions.ArticleSale.Default)]
        public async Task<ArticleSaleDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            return ObjectMapper.Map<ArticleSale, ArticleSaleDto>(result);
        }

        [Authorize(CmsAdminPermissions.ArticleSale.Default)]
        public async Task<PagedResultDto<ArticleSaleDto>> GetListAsync(ArticleSalesListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(null, input.ArticleId, 
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfther, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, null,
                input.ArticleId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfther, input.CreationBefore, input.Filter);

            return new PagedResultDto<ArticleSaleDto>(
                totalCount,
                ObjectMapper.Map<List<ArticleSale>, List<ArticleSaleDto>>(list)
            );
        }

        [Authorize(CmsAdminPermissions.ArticleSale.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

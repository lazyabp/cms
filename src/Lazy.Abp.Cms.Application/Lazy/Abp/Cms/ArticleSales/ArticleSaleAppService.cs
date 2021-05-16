using Lazy.Abp.Cms.ArticleSales.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Lazy.Abp.Cms.ArticleSales
{
    [Authorize]
    public class ArticleSaleAppService : CmsAppService, IArticleSaleAppService, ITransientDependency
    {
        private readonly IArticleSaleRepository _repository;
        
        public ArticleSaleAppService(IArticleSaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArticleSaleDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<ArticleSale, ArticleSaleDto>(result);
        }

        public async Task<PagedResultDto<ArticleSaleDto>> GetListAsync(ArticleSalesListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.ArticleId, 
                input.IsPaid, input.PaidTimeAfter, input.PaidTimeBefore, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, 
                CurrentUser.GetId(), input.ArticleId, input.IsPaid, input.PaidTimeAfter, input.PaidTimeBefore, input.Filter);

            return new PagedResultDto<ArticleSaleDto>(
                totalCount,
                ObjectMapper.Map<List<ArticleSale>, List<ArticleSaleDto>>(list)
            );
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(result);
        }
    }
}

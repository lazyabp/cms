using System;
using Lazy.Abp.Cms.Permissions;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.Users;
using System.Collections.Generic;
using Volo.Abp;
using Microsoft.AspNetCore.Authorization;

namespace Lazy.Abp.Cms
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

        public async Task<PagedResultDto<ArticleSaleDto>> GetListAsync(GetArticleSalesListRequestDto input)
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

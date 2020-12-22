using System;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LazyAbp.CmsKit
{
    public class SinglePageAppService : CmsKitAppService, ISinglePageAppService, ITransientDependency        
    {
        private readonly ISinglePageRepository _repository;
        
        public SinglePageAppService(ISinglePageRepository repository)
        {
            _repository = repository;
        }

        public async Task<SinglePageDto> GetAsync(Guid id)
        {
            var page = await _repository.GetAsync(id);

            return ObjectMapper.Map<SinglePage, SinglePageDto>(page);
        }

        public async Task<SinglePageDto> GetByName(string name)
        {
            var page = await _repository.GetByNameAsync(name);

            return ObjectMapper.Map<SinglePage, SinglePageDto>(page);
        }

        public async Task<PagedResultDto<SinglePageDto>> GetListAsync(GetSinglePageListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.CreatedAfter, input.CreatedBefore, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, input.CreatedAfter, input.CreatedBefore, input.Filter);

            return new PagedResultDto<SinglePageDto>(
                totalCount,
                ObjectMapper.Map<List<SinglePage>, List<SinglePageDto>>(list)
            );
        }
    }
}

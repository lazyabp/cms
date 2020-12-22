using System;
using LazyAbp.CmsKit.Permissions;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.CmsKit
{
    public class TagAppService : CmsKitAppService, ITagAppService, ITransientDependency
    {
        private readonly ITagRepository _repository;
        
        public TagAppService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<TagDto>> GetListAsync(GetTagListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync();
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, input.Filter);

            return new PagedResultDto<TagDto>(
                totalCount,
                ObjectMapper.Map<List<Tag>, List<TagDto>>(list)
            );
        }

        public async Task<int> IncHits(Guid id)
        {
            var tag = await _repository.GetAsync(id);
            tag.IncHits();

            return tag.Hits;
        }
    }
}

using System;
using Lazy.Abp.Cms.Permissions;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Lazy.Abp.Cms
{
    public class CategoryAppService : CmsAppService, ICategoryAppService, ITransientDependency
    {
        private readonly ICategoryRepository _repository;
        
        public CategoryAppService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetByRootAsync(Guid? id)
        {
            var categories = await _repository.GetByRootIdAsync(id);

            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public async Task<List<CategoryDto>> GetByParentAsync(Guid? id)
        {
            var categories = await _repository.GetByParentIdAsync(id);

            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public async Task<List<CategoryDto>> GetPathAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);
            var result = new List<CategoryDto>();
            var path = new List<Guid>();

            if (category.Path.IsNullOrEmpty() || category.Path == id.ToString())
            {
                result.Add(ObjectMapper.Map<Category, CategoryDto>(category));

                return result;
            }

            foreach (var categoryId in category.Path.Split(","))
            {
                path.Add(Guid.Parse(categoryId));
            }

            var categories = await _repository.GetByIdsAsync(path);
            foreach(var categoryId in path)
            {
                var cat = categories.FirstOrDefault(x => x.Id == categoryId);
                result.Add(ObjectMapper.Map<Category, CategoryDto>(cat));
            }

            return result;
        }

        public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.ParentId, input.RootId, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, input.ParentId, input.RootId, input.Filter);

            return new PagedResultDto<CategoryDto>(
                totalCount,
                ObjectMapper.Map<List<Category>, List<CategoryDto>>(list)
            );
        }
    }
}

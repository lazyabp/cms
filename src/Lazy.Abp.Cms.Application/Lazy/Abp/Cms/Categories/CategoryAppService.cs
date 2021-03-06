using Lazy.Abp.Cms.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Categories
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

        public async Task<List<CategoryViewDto>> GetByRootAsync(Guid? id)
        {
            var categories = await _repository.GetByRootIdAsync(id);

            return ObjectMapper.Map<List<Category>, List<CategoryViewDto>>(categories);
        }

        public async Task<List<CategoryViewDto>> GetByParentAsync(Guid? id)
        {
            var categories = await _repository.GetByParentIdAsync(id);

            return ObjectMapper.Map<List<Category>, List<CategoryViewDto>>(categories);
        }

        public async Task<List<CategoryViewDto>> GetPathAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);
            var result = new List<CategoryViewDto>();
            var path = new List<Guid>();

            if (category.Path.IsNullOrEmpty() || category.Path == id.ToString())
            {
                result.Add(ObjectMapper.Map<Category, CategoryViewDto>(category));

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
                result.Add(ObjectMapper.Map<Category, CategoryViewDto>(cat));
            }

            return result;
        }

        public async Task<ListResultDto<CategoryViewDto>> GetAll()
        {
            var categories = await _repository.GetListAsync(false);
            categories = categories
                .OrderBy(q => q.DisplayOrder)
                .ThenBy(q => q.CreationTime)
                .ToList();

            var dtos = ObjectMapper.Map<List<Category>, List<CategoryViewDto>>(categories);

            return new ListResultDto<CategoryViewDto>(dtos);
        }

        public async Task<PagedResultDto<CategoryViewDto>> GetListAsync(CategoryListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.ParentId, input.RootId, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, input.ParentId, input.RootId, input.Filter);

            return new PagedResultDto<CategoryViewDto>(
                totalCount,
                ObjectMapper.Map<List<Category>, List<CategoryViewDto>>(list)
            );
        }
    }
}

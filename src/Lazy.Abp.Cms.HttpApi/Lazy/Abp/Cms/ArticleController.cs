using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.Articles.Dtos;
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
    [ControllerName("Article")]
    [Route("api/cms/articles")]
    public class ArticleController : AbpController, IArticleAppService
    {
        private readonly IArticleAppService _service;

        public ArticleController(IArticleAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("{id}/content")]
        public Task<ArticleContentDto> GetContentAsync(Guid id)
        {
            return _service.GetContentAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleDto>> GetListAsync(GetArticleListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("by-tag/{tag}")]
        public Task<PagedResultDto<ArticleDto>> GetListByTagAsync(string tag)
        {
            return _service.GetListByTagAsync(tag);
        }

        [HttpGet]
        [Route("by-tag-id/{id}")]
        public Task<PagedResultDto<ArticleDto>> GetListByTagIdAsync(Guid id)
        {
            return _service.GetListByTagIdAsync(id);
        }

        [HttpPost]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}/hits")]
        public Task<int> IncHits(Guid id)
        {
            return _service.IncHits(id);
        }

        [HttpPost]
        [Route("{id}/like")]
        public Task<int> AddLike(Guid id)
        {
            return _service.AddLike(id);
        }

        [HttpDelete]
        [Route("{id}/like")]
        public Task<int> RemoveLike(Guid id)
        {
            return _service.RemoveLike(id);
        }

        [HttpPost]
        [Route("{id}/dislike")]
        public Task<int> AddDislike(Guid id)
        {
            return _service.AddDislike(id);
        }

        [HttpDelete]
        [Route("{id}/dislike")]
        public Task<int> RemoveDislike(Guid id)
        {
            return _service.RemoveDislike(id);
        }

        [HttpPost]
        [Route("{id}/favorite")]
        public Task<int> AddFavorite(Guid id)
        {
            return _service.AddFavorite(id);
        }

        [HttpDelete]
        [Route("{id}/favorite")]
        public Task<int> RemoveFavorite(Guid id)
        {
            return _service.RemoveFavorite(id);
        }

        [HttpPut]
        [Route("{id}/set-active")]
        public Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            return _service.SetActiveAsync(id, input);
        }
    }
}

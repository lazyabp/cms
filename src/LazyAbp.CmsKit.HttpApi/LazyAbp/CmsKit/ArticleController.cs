using LazyAbp.CmsKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.CmsKit
{
    [RemoteService(Name = CmsKitRemoteServiceConsts.RemoteServiceName)]
    [Area("cmskit")]
    [ControllerName("Article")]
    [Route("api/cmskit/articles")]
    public class ArticleController : AbpController, IArticleAppService
    {
        private readonly IArticleAppService _service;

        public ArticleController(IArticleAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleViewDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("{id}/content")]
        public Task<string> GetContentAsync(Guid id, string key)
        {
            return _service.GetContentAsync(id, key);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("by-tag/{tag}")]
        public Task<PagedResultDto<ArticleViewDto>> GetListByTagAsync(string tag)
        {
            return _service.GetListByTagAsync(tag);
        }

        [HttpGet]
        [Route("by-tag-id/{id}")]
        public Task<PagedResultDto<ArticleViewDto>> GetListByTagIdAsync(Guid id)
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

        [HttpPut]
        [Route("{id}/like/add")]
        public Task<int> AddLike(Guid id)
        {
            return _service.AddLike(id);
        }

        [HttpPut]
        [Route("{id}/like/remove")]
        public Task<int> RemoveLike(Guid id)
        {
            return _service.RemoveLike(id);
        }

        [HttpPut]
        [Route("{id}/dislike/add")]
        public Task<int> AddDislike(Guid id)
        {
            return _service.AddDislike(id);
        }

        [HttpPut]
        [Route("{id}/dislike/remove")]
        public Task<int> RemoveDislike(Guid id)
        {
            return _service.RemoveDislike(id);
        }

        [HttpPut]
        [Route("{id}/favorite/add")]
        public Task<int> AddFavorite(Guid id)
        {
            return _service.AddFavorite(id);
        }

        [HttpPut]
        [Route("{id}/favorite/remove")]
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

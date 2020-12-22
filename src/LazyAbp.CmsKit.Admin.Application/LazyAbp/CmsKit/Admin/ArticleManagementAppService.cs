using System;
using LazyAbp.CmsKit.Admin.Permissions;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Users;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LazyAbp.CmsKit.Admin
{
    public class ArticleManagementAppService : ApplicationService, IArticleManagementAppService
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleCommonAppService _articleCommonAppService;

        public ArticleManagementAppService(IArticleRepository repository,
            IArticleCommonAppService articleCommonAppService)
        {
            _repository = repository;
            _articleCommonAppService = articleCommonAppService;
        }

        [Authorize(CmsKitAdminPermissions.Article.Default)]
        public Task<ArticleViewDto> GetAsync(Guid id)
        {
            return _articleCommonAppService.GetAsync(id);
        }

        [Authorize(CmsKitAdminPermissions.Article.Default)]
        public Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input)
        {
            return _articleCommonAppService.GetListAsync(input);
        }

        [Authorize(CmsKitAdminPermissions.Article.Create)]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _articleCommonAppService.CreateAsync(input);
        }

        [Authorize(CmsKitAdminPermissions.Article.Update)]
        public Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            return _articleCommonAppService.UpdateAsync(id, input);
        }

        [Authorize(CmsKitAdminPermissions.Article.Update)]
        public Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            return _articleCommonAppService.SetActiveAsync(id, input);
        }

        [Authorize(CmsKitAdminPermissions.Article.Audit)]
        public Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input)
        {
            return _articleCommonAppService.AuditAsync(id, input);
        }

        [Authorize(CmsKitAdminPermissions.Article.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}

using Lazy.Abp.Cms.Admin.Permissions;
using Lazy.Abp.Cms.ArticleAuditLogs.Dtos;
using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.Articles.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin
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

        [Authorize(CmsAdminPermissions.Article.Default)]
        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _articleCommonAppService.GetAsync(id);
        }

        [Authorize(CmsAdminPermissions.Article.Default)]
        public Task<PagedResultDto<ArticleDto>> GetListAsync(GetArticleListRequestDto input)
        {
            return _articleCommonAppService.GetListAsync(input);
        }

        [Authorize(CmsAdminPermissions.Article.Create)]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _articleCommonAppService.CreateAsync(input);
        }

        [Authorize(CmsAdminPermissions.Article.Update)]
        public Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            return _articleCommonAppService.UpdateAsync(id, input);
        }

        [Authorize(CmsAdminPermissions.Article.Update)]
        public Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            return _articleCommonAppService.SetActiveAsync(id, input);
        }

        [Authorize(CmsAdminPermissions.Article.Audit)]
        public Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input)
        {
            return _articleCommonAppService.AuditAsync(id, input);
        }

        [Authorize(CmsAdminPermissions.Article.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}

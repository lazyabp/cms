using System;
using System.Threading.Tasks;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Admin
{
    public interface IArticleManagementAppService : IApplicationService, ITransientDependency
    {
        Task<ArticleViewDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input);

        Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input);

        Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input);

        Task SetActiveAsync(Guid id, SetActiveRequestDto input);

        Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input);

        Task DeleteAsync(Guid id);
    }
}
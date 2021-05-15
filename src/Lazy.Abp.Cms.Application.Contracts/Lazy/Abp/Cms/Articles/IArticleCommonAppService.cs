using Lazy.Abp.Cms.ArticleAuditLogs.Dtos;
using Lazy.Abp.Cms.Articles.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Articles
{
    public interface IArticleCommonAppService : ITransientDependency
    {
        Task<ArticleDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleDto>> GetListAsync(GetArticleListRequestDto input);

        Task<PagedResultDto<ArticleDto>> GetListByTagAsync(GetArticleListByTagRequestDto input);

        Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input);

        Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input);

        Task SetActiveAsync(Guid id, SetActiveRequestDto input);

        Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input);
    }
}

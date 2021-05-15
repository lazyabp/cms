using Lazy.Abp.Cms.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms
{
    public interface IArticleCommonAppService : ITransientDependency
    {
        Task<ArticleViewDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input);

        Task<PagedResultDto<ArticleViewDto>> GetListByTagAsync(GetArticleListByTagRequestDto input);

        Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input);

        Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input);

        Task SetActiveAsync(Guid id, SetActiveRequestDto input);

        Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input);
    }
}

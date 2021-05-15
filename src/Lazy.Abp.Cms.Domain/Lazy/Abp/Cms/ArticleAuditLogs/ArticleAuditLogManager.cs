using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.Cms.ArticleAuditLogs
{
    public class ArticleAuditLogManager : DomainService, IArticleAuditLogManager, ITransientDependency
    {
        private readonly IArticleAuditLogRepository _repository;

        public ArticleAuditLogManager(IArticleAuditLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArticleAuditLog> WriteAsync(Guid articleId, Guid? tenantId, AuditStatus status, string remark)
        {
            var log = new ArticleAuditLog(GuidGenerator.Create(), tenantId, articleId, status, remark);

            return await _repository.InsertAsync(log);
        }
    }
}

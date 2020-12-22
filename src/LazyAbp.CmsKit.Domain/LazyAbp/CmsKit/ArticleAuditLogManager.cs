using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace LazyAbp.CmsKit
{
    public class ArticleAuditLogManager : DomainService, IArticleAuditLogManager, ITransientDependency
    {
        private readonly IArticleAuditLogRepository _repository;

        public ArticleAuditLogManager(IArticleAuditLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArticleAuditLog> WriteAsync(Guid articleId, AuditStatus status, string remark)
        {
            var log = new ArticleAuditLog(GuidGenerator.Create(), articleId, status, remark);

            return await _repository.InsertAsync(log);
        }
    }
}

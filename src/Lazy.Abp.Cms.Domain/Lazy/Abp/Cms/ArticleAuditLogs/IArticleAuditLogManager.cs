using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.ArticleAuditLogs
{
    public interface IArticleAuditLogManager : ITransientDependency
    {
        Task<ArticleAuditLog> WriteAsync(Guid articleId, Guid? tenantId, AuditStatus status, string remark);
    }
}

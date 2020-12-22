using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.CmsKit
{
    public interface IArticleAuditLogManager : ITransientDependency
    {
        Task<ArticleAuditLog> WriteAsync(Guid articleId, AuditStatus status, string remark);
    }
}

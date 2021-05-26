using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.Cms.ArticleSales
{
    public class ArticleSaleManager : DomainService
    {
        private IArticleSaleRepository _repository;

        public ArticleSaleManager(IArticleSaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArticleSale> GetAsync(Guid id, Guid? tenantId, bool includeDetails = true)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetAsync(id, includeDetails);
            }
        }

        public async Task<ArticleSale> CreateAsync(
            Guid? tenantId,
            Guid userId,
            Guid articleId,
            string orderId,
            decimal paidAmount
        )
        {
            var articleSale = new ArticleSale(GuidGenerator.Create(), tenantId, userId, articleId, orderId, paidAmount);

            return await _repository.InsertAsync(articleSale);
        }
    }
}

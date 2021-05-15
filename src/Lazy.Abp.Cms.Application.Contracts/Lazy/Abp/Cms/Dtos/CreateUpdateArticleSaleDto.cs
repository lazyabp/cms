using System;
using System.ComponentModel;
namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateArticleSaleDto
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }
    }
}
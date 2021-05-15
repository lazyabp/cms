using System.Threading.Tasks;

namespace Lazy.Abp.Cms.Web.Pages.Cms.Article
{
    public class IndexModel : CmsPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}

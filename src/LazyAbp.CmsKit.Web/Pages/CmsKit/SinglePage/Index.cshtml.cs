using System.Threading.Tasks;

namespace LazyAbp.CmsKit.Web.Pages.CmsKit.SinglePage
{
    public class IndexModel : CmsKitPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}

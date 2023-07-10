using Microsoft.AspNetCore.Authorization;

namespace KetabBaz.Web.Pages.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

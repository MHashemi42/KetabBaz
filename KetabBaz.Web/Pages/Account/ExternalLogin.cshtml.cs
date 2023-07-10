using KetabBaz.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabBaz.Web.Pages.Account
{
    public class ExternalLoginModel : PageModel
    {
        private readonly IUserService _userService;

        public ExternalLoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            string redirectUrl = Url
                .Page("ExternalLoginCallback", null, new { returnUrl }, Request.Scheme);

            AuthenticationProperties properties = _userService
                .ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }
    }
}

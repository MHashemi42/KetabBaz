using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabBaz.Web.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly IUserService _userService;

        public ConfirmEmailModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(string token, string email)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return RedirectToPage("/Error");
            }

            User user = await _userService.FindByEmailAsync(email);
            if (user is null)
            {
                return RedirectToPage("/Error");
            }

            token = TokenUrlEncoder.DecodeToken(token);
            bool succeeded = await _userService.ConfirmEmailAsync(user, token);

            return succeeded ? Page() : RedirectToPage("/Error");
        }
    }
}

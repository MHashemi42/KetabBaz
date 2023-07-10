using KetabBaz.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KetabBaz.Web.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService _userService;

        public LogoutModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _userService.LogoutUserAsync();

            return RedirectToPage("/Index");
        }
    }
}

using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using KetabBaz.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace KetabBaz.Web.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty(SupportsGet = true)]
        public ResetPassword ResetPassword { get; set; }

        public ResetPasswordModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet(string token, string email)
        {
            ResetPassword = new ResetPassword
            {
                Token = token,
                Email = email
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ResetPassword.Token = TokenUrlEncoder.DecodeToken(ResetPassword.Token);

            ResetPasswordResult result = await _userService.ResetPassword(ResetPassword);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.TryAddModelError(string.Empty, item.Value);
                }

                return Page();
            }

            return RedirectToPage("ResetPasswordConfirmation");
        }
    }
}

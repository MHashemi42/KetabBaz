using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;

namespace KetabBaz.Web.Pages.Account
{
    public class ExternalLoginCallbackModel : PageModel
    {
        private readonly IUserService _userService;

        public ExternalLoginCallbackModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ExternalLoginInfo info = await _userService.GetExternalLoginInfoAsync();
            if (info is null)
            {
                return RedirectToPage("Login");
            }

            UserLoginResult result = await _userService
                .ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: false, bypassTwoFactor: false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("ForgetPassword");
            }
            
            return RedirectToPage("ExternalLoginConfirmation", new { returnUrl });
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToPage("/Index");
        }
    }
}

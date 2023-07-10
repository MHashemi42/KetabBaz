using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using KetabBaz.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace KetabBaz.Web.Pages.Account
{
    public class ExternalLoginConfirmationModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public ExternalLoginConfirmationModel(IUserService userService,
            IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/Error");
            }

            ExternalLoginInfo info = await _userService.GetExternalLoginInfoAsync();
            if (info is null)
            {
                return RedirectToPage("/Error");
            }

            string email = info.Principal.FindFirst(ClaimTypes.Email).Value;

            User user = await _userService.FindByEmailAsync(email);
            if (user != null)
            {
                bool succeeded = await _userService.AddLoginAsync(user, info);
                if (succeeded)
                {
                    await _userService.LoginUserAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
            }

            string userName = email.Substring(0, email.IndexOf('@'));

            user = new User { Email = email, UserName = userName };
            UserRegistrationResult result = await _userService.RegisterUserAsync(user);
            if (result.Succeeded)
            {
                bool succeeded = await _userService.AddLoginAsync(user, info);
                if (succeeded)
                {
                    await SendEmailForConfirmEmailAsync(user.Email);
                    await _userService.LoginUserAsync(user, isPersistent: false);
                }
            }

            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToPage("/Index");
        }

        private async Task SendEmailForConfirmEmailAsync(string email)
        {
            string token = await _userService
                        .GenerateEmailConfirmationTokenAsync(email);
            token = TokenUrlEncoder.EncodeToken(token);

            string confirmationLink = Url.Page("ConfirmEmail", null,
                new { token, email = email }, Request.Scheme);

            await _emailService.SendEmailAsync(new EmailMessage
            {
                Content = confirmationLink,
                Subject = "تایید کردن ایمیل",
                To = email
            });
        }
    }
}

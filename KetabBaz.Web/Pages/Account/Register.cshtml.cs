using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using KetabBaz.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace KetabBaz.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        [BindProperty]
        public UserRegistration UserRegistration { get; set; }

        public RegisterModel(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public IActionResult OnGet()
        {
            if (User.Identities.Any(i => i.IsAuthenticated))
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserRegistrationResult result = await _userService
                .RegisterUserAsync(UserRegistration);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.TryAddModelError(string.Empty, item.Value);
                }

                return Page();
            }

            string token = await _userService
                .GenerateEmailConfirmationTokenAsync(UserRegistration.Email);
            token = TokenUrlEncoder.EncodeToken(token);

            string confirmationLink = Url.Page("ConfirmEmail", null,
                new { token, email = UserRegistration.Email }, Request.Scheme);

            await _emailService.SendEmailAsync(new EmailMessage
            {
                Content = confirmationLink,
                Subject = "تایید کردن ایمیل",
                To = UserRegistration.Email
            });

            return RedirectToPage("SuccessRegistration");
        }
    }
}

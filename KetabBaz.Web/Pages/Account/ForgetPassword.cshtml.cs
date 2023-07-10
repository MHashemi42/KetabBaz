using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using KetabBaz.Web.Helpers;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace KetabBaz.Web.Pages.Account;

public class ForgetPasswordModel : PageModel
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    [BindProperty]
    public ForgetPassword ForgetPassword { get; set; }

    public ForgetPasswordModel(IUserService userService, IEmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        string token = await _userService
            .GeneratePasswordResetTokenAsync(ForgetPassword.Email);

        if (!string.IsNullOrWhiteSpace(token))
        {
            token = TokenUrlEncoder.EncodeToken(token);
            string callback = Url.Page("ResetPassword", null,
                new { token, email = ForgetPassword.Email }, Request.Scheme);

            await _emailService.SendEmailAsync(new EmailMessage
            {
                Content = callback,
                Subject = "فراموشی رمز عبور",
                To = ForgetPassword.Email
            });            
        }

        return RedirectToPage("ForgetPasswordConfirmation");
    }
}

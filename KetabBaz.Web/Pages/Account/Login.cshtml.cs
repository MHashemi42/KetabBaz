using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace KetabBaz.Web.Pages.Account;

public class LoginModel : PageModel
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    [BindProperty]
    public UserLogin UserLogin { get; set; }

    public LoginModel(IUserService userService, IEmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }

    public IActionResult OnGet(string returnUrl = null)
    {
        if (User.Identities.Any(i => i.IsAuthenticated))
        {
            return RedirectToPage("/Index");
        }

        ViewData[nameof(returnUrl)] = returnUrl;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        UserLoginResult result = await _userService.LoginUserAsync(UserLogin);
        if (result.Succeeded)
        {
            return RedirectToLocal(returnUrl);
        }

        if (result.RequiresTwoFactor)
        {
            return RedirectToPage("TwoStepLogin",
                new { UserLogin.Email, UserLogin.RememberMe, returnUrl });
        }

        if (result.IsLockedOut)
        {
            await NotifyUserIsLockedOut();
            ModelState.AddModelError(string.Empty, ".اکانت مورد نظر قفل شده است");
        }
        else
        {
            ModelState.AddModelError(string.Empty, ".اطلاعات ورود شما با هم مطابقت ندارد");
        }

        return Page();
    }

    private IActionResult RedirectToLocal(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        else
            return RedirectToPage("/Index");
    }

    private async Task NotifyUserIsLockedOut()
    {
        string forgotPassLink = Url
                .Page("ForgetPassword", null, new { }, Request.Scheme);
        string content =
            $"اکانت شما قفل شده است، لطفا برای بازنشانی رمز عبور لینک زیر را کلیک نمایید: {forgotPassLink}";

        await _emailService.SendEmailAsync(new EmailMessage
        {
            Content = content,
            Subject = "قفل شدن اکانت",
            To = UserLogin.Email
        });
    }
}

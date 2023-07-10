using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;

namespace KetabBaz.Web.Pages.Account
{
    public class TwoStepLoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        [BindProperty]
        public UserTwoStepLogin TwoStepLogin { get; set; }

        public TwoStepLoginModel(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<IActionResult> OnGet(string email, bool rememberMe,
            string returnUrl = null)
        {
            User user = await _userService.FindByEmailAsync(email);
            if (user is null)
            {
                return RedirectToPage("/Error");
            }

            IEnumerable<string> providers = await _userService
                .GetValidTwoFactorProvidersAsync(user);
            if (!providers.Contains("Email"))
            {
                return RedirectToPage("/Error");
            }

            string token = await _userService
                .GenerateTwoFactorTokenAsync(user, "Email");

            await _emailService.SendEmailAsync(new EmailMessage
            {
                Subject = "ورود دو مرحله ای",
                To = user.Email,
                Content = token
            });

            ViewData[nameof(returnUrl)] = returnUrl;
            ViewData[nameof(rememberMe)] = rememberMe;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = await _userService
                .GetTwoFactorAuthenticationUserAsync();
            if (user is null)
            {
                return RedirectToPage("/Error");
            }

            UserLoginResult result = await _userService.TwoFactorSignInAsync("Email",
                TwoStepLogin.TwoFactorCode, TwoStepLogin.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                await NotifyUserIsLockedOut(user.Email);
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

        private async Task NotifyUserIsLockedOut(string email)
        {
            string forgotPassLink = Url
                    .Page("ForgetPassword", null, new { }, Request.Scheme);
            string content =
                $"اکانت شما قفل شده است، لطفا برای بازنشانی رمز عبور لینک زیر را کلیک نمایید: {forgotPassLink}";

            await _emailService.SendEmailAsync(new EmailMessage
            {
                Content = content,
                Subject = "قفل شدن اکانت",
                To = email
            });
        }
    }
}

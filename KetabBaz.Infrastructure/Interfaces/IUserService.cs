using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace KetabBaz.Infrastructure.Interfaces;

public interface IUserService
{
    Task<UserRegistrationResult> RegisterUserAsync(UserRegistration userRegistration);
    Task<UserRegistrationResult> RegisterUserAsync(User user);
    Task<UserLoginResult> LoginUserAsync(UserLogin userLogin);
    Task LoginUserAsync(User user, bool isPersistent);
    Task LogoutUserAsync();
    Task<string> GeneratePasswordResetTokenAsync(string email);
    Task<ResetPasswordResult> ResetPassword(ResetPassword resetPassword);
    Task<string> GenerateEmailConfirmationTokenAsync(string email);
    Task<User> FindByEmailAsync(string email);
    Task<bool> ConfirmEmailAsync(User user, string token);
    Task<IEnumerable<string>> GetValidTwoFactorProvidersAsync(User user);
    Task<string> GenerateTwoFactorTokenAsync(User user, string tokenProvider);
    Task<User> GetTwoFactorAuthenticationUserAsync();
    Task<UserLoginResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
    AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
    Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
    Task<UserLoginResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    Task<bool> AddLoginAsync(User user, ExternalLoginInfo info);
}

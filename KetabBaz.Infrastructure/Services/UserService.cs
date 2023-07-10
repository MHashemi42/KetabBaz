using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace KetabBaz.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, IMapper mapper,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task<bool> AddLoginAsync(User user, ExternalLoginInfo info)
    {
        IdentityResult result = await _userManager.AddLoginAsync(user, info);

        return result.Succeeded;
    }

    public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
    {
        return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
    }

    public async Task<bool> ConfirmEmailAsync(User user, string token)
    {
        IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);

        return result.Succeeded;
    }

    public async Task<UserLoginResult> ExternalLoginSignInAsync(string loginProvider,
        string providerKey, bool isPersistent, bool bypassTwoFactor)
    {
        SignInResult result = await  _signInManager
            .ExternalLoginSignInAsync(loginProvider, providerKey, 
            isPersistent, bypassTwoFactor);

        return new UserLoginResult
        {
            Succeeded = result.Succeeded,
            IsLockedOut = result.IsLockedOut,
            RequiresTwoFactor = result.RequiresTwoFactor
        };
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return null;
        }

        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
    {
        User user = await FindByEmailAsync(email);
        if (user is null)
        {
            return string.Empty;
        }

        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task<string> GeneratePasswordResetTokenAsync(string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return string.Empty;
        }

        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task<string> GenerateTwoFactorTokenAsync(User user, string tokenProvider)
    {
        return await _userManager.GenerateTwoFactorTokenAsync(user, tokenProvider);
    }

    public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
    {
        return await _signInManager.GetExternalLoginInfoAsync();
    }

    public async Task<User> GetTwoFactorAuthenticationUserAsync()
    {
        return await _signInManager.GetTwoFactorAuthenticationUserAsync();
    }

    public async Task<IEnumerable<string>> GetValidTwoFactorProvidersAsync(User user)
    {
        return await _userManager.GetValidTwoFactorProvidersAsync(user);
    }

    public async Task<UserLoginResult> LoginUserAsync(UserLogin userLogin)
    {
        User user = await FindByEmailAsync(userLogin.Email);
        if (user is null)
        {
            return new UserLoginResult { Succeeded = false };
        }

        string password = userLogin.Password;
        bool isPersistent = userLogin.RememberMe;
        bool lockoutOnFailure = true;

        SignInResult result = await _signInManager
            .PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        
        return new UserLoginResult
        {
            Succeeded = result.Succeeded,
            IsLockedOut = result.IsLockedOut,
            RequiresTwoFactor = result.RequiresTwoFactor,
        };
    }

    public async Task LoginUserAsync(User user, bool isPersistent)
    {
        if (user is null)
        {
            return;
        }

        await _signInManager.SignInAsync(user, isPersistent);
    }

    public async Task LogoutUserAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<UserRegistrationResult> RegisterUserAsync(UserRegistration userRegistration)
    {
        User user = _mapper.Map<User>(userRegistration);
        IdentityResult result = await _userManager.CreateAsync(user, userRegistration.Password);

        return new UserRegistrationResult
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.ToDictionary(key => key.Code, value => value.Description)
        };
    }

    public async Task<UserRegistrationResult> RegisterUserAsync(User user)
    {
        IdentityResult result = await _userManager.CreateAsync(user);

        return new UserRegistrationResult
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.ToDictionary(key => key.Code, value => value.Description)
        };
    }

    public async Task<ResetPasswordResult> ResetPassword(ResetPassword resetPassword)
    {
        User user = await _userManager.FindByEmailAsync(resetPassword.Email);
        if (user is null)
        {
            return new ResetPasswordResult { Succeeded = true };
        }

        IdentityResult result = await _userManager.ResetPasswordAsync(user, resetPassword.Token,
            resetPassword.Password);
        if (!result.Succeeded)
        {
            return new ResetPasswordResult
            {
                Succeeded = false,
                Errors = result.Errors.ToDictionary(key => key.Code, value => value.Description)
            };
        }

        await _userManager.SetLockoutEnabledAsync(user, enabled: false);

        return new ResetPasswordResult { Succeeded = true };
    }

    public async Task<UserLoginResult> TwoFactorSignInAsync(string provider, string code,
        bool isPersistent, bool rememberClient)
    {
        if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(code))
        {
            return new UserLoginResult { Succeeded = false };
        }
        
        SignInResult result = await _signInManager
            .TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);

        return new UserLoginResult
        {
            Succeeded = result.Succeeded,
            IsLockedOut = result.IsLockedOut,
            RequiresTwoFactor = result.RequiresTwoFactor
        };
    }
}

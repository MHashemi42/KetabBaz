using Microsoft.AspNetCore.Identity;

namespace KetabBaz.Infrastructure.Data.CustomValdiators;

public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
{
    public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
    {
        string userName = await manager.GetUserNameAsync(user);
        if (userName.ToLower().Equals(password.ToLower()))
        {
            return IdentityResult.Failed(new IdentityError
            {
                Description = "نام کاربری و رمز عبور نمیتواند مثل هم باشد.",
                Code = "SameUserNamePassword"
            });
        }

        if (password.Contains("password", StringComparison.CurrentCultureIgnoreCase))
        {
            return IdentityResult.Failed(new IdentityError
            {
                Description = "رمز عبور نمیتواند شامل کلمه Password باشد.",
                Code = "PasswordContainsPasswordWord"
            });
        }

        return IdentityResult.Success;
    }
}

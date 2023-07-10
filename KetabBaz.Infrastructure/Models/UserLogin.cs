using System.ComponentModel.DataAnnotations;

namespace KetabBaz.Infrastructure.Models;

public class UserLogin
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نیست")]
    public string Email { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "من را بخاطر بسپار؟")]
    public bool RememberMe { get; set; }
}

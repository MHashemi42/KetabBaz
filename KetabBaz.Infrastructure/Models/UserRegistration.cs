using System.ComponentModel.DataAnnotations;

namespace KetabBaz.Infrastructure.Models;

public class UserRegistration
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    public string UserName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نیست")]
    public string Email { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "تکرار رمز عبور")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "{0} با {1} همخوانی ندارد")]
    public string ConfirmPassword { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace KetabBaz.Infrastructure.Models;

public class ResetPassword
{
    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "تکرار رمز عبور")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "{0} با {1} همخوانی ندارد")]
    public string ConfirmPassword { get; set; }

    public string Email { get; set; }
    public string Token { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace KetabBaz.Infrastructure.Models;

public class ForgetPassword
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نیست")]
    public string Email { get; set; }
}

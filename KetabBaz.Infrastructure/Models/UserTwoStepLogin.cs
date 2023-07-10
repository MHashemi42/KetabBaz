using System.ComponentModel.DataAnnotations;

namespace KetabBaz.Infrastructure.Models;

public class UserTwoStepLogin
{
    [Display(Name = "کد")]
    [Required(ErrorMessage = "{0} مورد نیاز است")]
    [DataType(DataType.Password)]
    public string TwoFactorCode { get; set; }

    public bool RememberMe { get; set; }
}

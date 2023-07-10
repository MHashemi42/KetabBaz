namespace KetabBaz.Infrastructure.Models;

public class UserLoginResult
{
    public bool Succeeded { get; set; }
    public bool IsLockedOut { get; set; }
    public bool RequiresTwoFactor { get; set; }
    public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
}

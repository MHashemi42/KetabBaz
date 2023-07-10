namespace KetabBaz.Infrastructure.Models;

public class UserRegistrationResult
{
    public bool Succeeded { get; set; }
    public Dictionary<string,string> Errors { get; set; } = new Dictionary<string,string>();
}

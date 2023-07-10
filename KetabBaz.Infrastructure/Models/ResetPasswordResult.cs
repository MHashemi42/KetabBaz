namespace KetabBaz.Infrastructure.Models;

public class ResetPasswordResult
{
    public bool Succeeded { get; set; }
    public Dictionary<string, string> Errors { get; set; }
}

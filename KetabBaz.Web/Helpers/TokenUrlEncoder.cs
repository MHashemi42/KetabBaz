using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace KetabBaz.Web.Helpers;

public static class TokenUrlEncoder
{
    public static string EncodeToken(string token)
        => WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
    public static string DecodeToken(string urlToken)
        => Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(urlToken));
}
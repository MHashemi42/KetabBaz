using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace KetabBaz.Web.Middlewares;

public class LogoutMiddleware
{
    private readonly RequestDelegate _next;

    public LogoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        if (context.Request.Path.StartsWithSegments("/account/logout"))
        {
            await userService.LogoutUserAsync();
            context.Response.Redirect("/");
        }
        else
        {
            await _next(context);
        }
    }
}

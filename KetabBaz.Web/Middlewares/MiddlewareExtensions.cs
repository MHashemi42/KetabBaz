namespace KetabBaz.Web.Middlewares;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseLogout(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LogoutMiddleware>();
    }
}

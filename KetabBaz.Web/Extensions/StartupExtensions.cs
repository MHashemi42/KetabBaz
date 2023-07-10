using KetabBaz.Infrastructure.Data.CustomValdiators;
using KetabBaz.Infrastructure.Data.Identity;
using KetabBaz.Infrastructure.Interfaces;
using KetabBaz.Web.CustomTokenProviders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System;

namespace KetabBaz.Web.Extensions;

public static class StartupExtensions
{
    public static void ConfigureRouteOptions(this IServiceCollection services) =>
        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = false;
        });

    public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<KetabBazDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

    public static void ConfigureIdentity(this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureIdentityCore(services);
        ConfigureDataProtectionTokenProviderOptions(services);
        ConfigureEmailConfirmationTokenProviderOptions(services);
        ConfigureGoogleAuthentication(services, configuration);
    }

    public static void ConfigureAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(KetabBazDbContext).Assembly);

    public static void ConfigureEmailService(this IServiceCollection services,
        IConfiguration configuration)
    {
        EmailConfiguration emailConfig = configuration
                                            .GetSection("EmailConfiguration")
                                            .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);
        services.AddScoped<IEmailService, MailKitEmailService>();
    }

    public static void ConfigureEntityRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICarouselRepository, CarouselRepository>();
        services.AddScoped<IBannerRepository, BannerRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISlideshowRepository, SlideshowRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
    }

    public static void ConfigureEntityServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICarouselService, CarouselService>();
        services.AddScoped<IBannerService, BannerService>();
        services.AddScoped<ISlideshowService, SlideshowService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IUserService, UserService>();
    }

    private static void ConfigureIdentityCore(IServiceCollection services) =>
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 3;
        })
          .AddEntityFrameworkStores<KetabBazDbContext>()
          .AddDefaultTokenProviders()
          .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation")
          .AddPasswordValidator<CustomPasswordValidator<User>>();

    private static void ConfigureDataProtectionTokenProviderOptions(IServiceCollection services) =>
        services.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromHours(2));

    private static void ConfigureEmailConfirmationTokenProviderOptions(IServiceCollection services) =>
        services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromDays(3));

    private static void ConfigureGoogleAuthentication(IServiceCollection services,
        IConfiguration configuration) =>
        services.AddAuthentication()
            .AddGoogle("Google", opt =>
            {
                IConfigurationSection googleAuth =
                    configuration.GetSection("Authentication:Google");

                opt.ClientId = googleAuth["ClientId"];
                opt.ClientSecret = googleAuth["ClientSecret"];
                opt.SignInScheme = IdentityConstants.ExternalScheme;
            });
}

using Microsoft.EntityFrameworkCore;
using Wishio.Business.Interfaces;
using Wishio.Business.MappingProfiles;
using Wishio.Business.Services;
using Wishio.Persistence;
using Wishio.Persistence.Interfaces;
using Wishio.Persistence.Repositories;

namespace Wishio.API;

public static class AppSetup
{
    public static void SetupServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IWishlistService, WishlistService>();
        builder.Services.AddScoped<IWishService, WishService>();
        builder.Services.AddScoped<IPictureService, PictureService>();
        builder.Services.AddScoped<IThemeService, ThemeService>();
    }

    public static void SetupRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
        builder.Services.AddScoped<IWishRepository, WishRepository>();
        builder.Services.AddScoped<IPictureRepository, PictureRepository>();
    }

    public static void SetupAutoMapper(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(_ => { },
            typeof(WishlistProfile),
            typeof(WishProfile));
    }

    public static void SetupEntityFramework(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<WishioContext>(options =>
        {
            if (builder.Environment.IsDevelopment()) options.EnableSensitiveDataLogging();
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void SetupSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void SetupControllers(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }
}
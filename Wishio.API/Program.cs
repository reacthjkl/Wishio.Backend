using Microsoft.EntityFrameworkCore;
using Wishio.Business.Interfaces;
using Wishio.Business.MappingProfiles;
using Wishio.Business.Services;
using Wishio.Persistence;
using Wishio.Persistence.Interfaces;
using Wishio.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg => { },
    typeof(WishlistProfile),
    typeof(WishProfile));

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup entity framework 
builder.Services.AddDbContext<WishioContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register application services
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<IWishService, WishService>();
builder.Services.AddScoped<IPictureService, PictureService>();

// Register repositories
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<IWishRepository, WishRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
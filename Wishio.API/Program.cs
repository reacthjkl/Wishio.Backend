using Wishio.Business.Interfaces;
using Wishio.Business.MappingProfiles;
using Wishio.Business.Services;
using Wishio.Persistance;
using Wishio.Persistance.Interfaces;
using Wishio.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg => { },
    typeof(WishlistProfile),
    typeof(WishProfile));

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup entity framework 
builder.Services.AddDbContext<WishioContext>();

// Register application services
builder.Services.AddScoped<IWishlistService, WishlistService>();

// Register repositories
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();

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
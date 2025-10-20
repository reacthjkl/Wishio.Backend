using Wishio.API;

var builder = WebApplication.CreateBuilder(args);

AppSetup.SetupAutoMapper(builder);
AppSetup.SetupSwagger(builder);
AppSetup.SetupEntityFramework(builder);
AppSetup.SetupServices(builder);
AppSetup.SetupRepositories(builder);
AppSetup.SetupControllers(builder);

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
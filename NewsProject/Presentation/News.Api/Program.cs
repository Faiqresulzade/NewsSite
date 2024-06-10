using News.Api.AllRegistrations;
using News.Application.Registrations;
using News.Application.Utilities.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);


AllRegistration.RegisterAllDI(builder);

var app = builder.Build();


FileHelper.Configure(app.Services.GetRequiredService<IHostEnvironment>());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.AddAplication();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

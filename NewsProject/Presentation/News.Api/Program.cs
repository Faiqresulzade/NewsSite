using News.Api.AllRegistrations;
using News.Application.Registrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json",false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json",true);


AllRegistration.RegisterAllDI(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAplication();

app.UseAuthorization();

app.MapControllers();

app.Run();

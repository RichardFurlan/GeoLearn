using DotNetEnv;
using GeoLearn.Application.Application;
using GeoLearn.Application.Application.Auth;
using GeoLearn.Domain.Repositories;
using GeoLearn.Domain.Services;
using GeoLearn.Infra.AuthServices;
using GeoLearn.Infra.IAServices;
using GeoLearn.Infra.Persistence;
using GeoLearn.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
Env.Load();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAplicAuth, AplicAuth>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddDbContext<GeoLearnDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddHttpClient<OpenAIService>(client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/"); // Configura o endpoint base, se necessário
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoLearn API V1");
    c.RoutePrefix = string.Empty; // This makes Swagger UI available at the app's root
});

app.UseHttpsRedirection();
app.UseHsts();

app.Use(async (context, next) =>
{
    if (context.Request.IsHttps || context.Request.Host.Host.Contains("localhost"))
    {
        await next();
    }
    else
    {
        var httpsUrl = $"https://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
        context.Response.Redirect(httpsUrl);
    }
});

app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
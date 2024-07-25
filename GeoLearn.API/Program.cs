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

string? connectionString;

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("Database");
}
else
{
    // Use environment variables in production
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    connectionString = databaseUrl ?? builder.Configuration.GetConnectionString("Database");
}
builder.Services.AddDbContext<GeoLearnDbContext>(options =>
    options.UseNpgsql(connectionString));
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
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("DefaultPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
using DotNetEnv;
using GeoLearn.Application.Application;
using GeoLearn.Application.Application.Admin;
using GeoLearn.Application.Application.Auth;
using GeoLearn.Domain.Repositories;
using GeoLearn.Domain.Services;
using GeoLearn.Infra.AuthServices;
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
builder.Services.AddScoped<IAplicAdmin, AplicAdmin>(); 
builder.Services.AddScoped<IQuizRepository, QuizRepository>(); // ou o repositório apropriado





    var dataBase = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<GeoLearnDbContext>(options =>
    options.UseNpgsql(dataBase));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
;

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
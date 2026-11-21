using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI;
using PersonalBloggingPlatformAPI.Data;
using PersonalBloggingPlatformAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonalBloggingPlatformAPI.Data.AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "personal_blogging_platform_db")
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ArticleEndpoints.routeGroupBuilder(app);

app.UseCors();
app.MapHealthChecks("/health").AllowAnonymous();

app.Run();

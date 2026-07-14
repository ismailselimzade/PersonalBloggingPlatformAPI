using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Data;
using PersonalBloggingPlatformAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonalBloggingPlatformAPI.Data.AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonalBloggingDb;Trusted_Connection=True;"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.MapPost("/articles", async ([FromBody] Article article, AppDbContext db) =>
{
    db.Articles.Add(article);
    await db.SaveChangesAsync();
    return Results.Ok(article);
});

app.MapGet("/articles", async (AppDbContext db) =>
{
    var articles = await db.Articles.ToListAsync();
    return Results.Ok(articles);
});

app.MapGet("/articles/{id}", async (AppDbContext db, int id) =>
{
    var article = await db.Articles.FindAsync(id);
    return article == null ? Results.NotFound() : Results.Ok(article);
});

app.MapPut("articles/{id}", async ([FromBody] Article updateArticle, AppDbContext db, int id) =>
{
    var articles = await db.Articles.FindAsync(id);

    if (articles != null)
    {
        articles.Title = updateArticle.Title;
        articles.Content = updateArticle.Content;
        await db.SaveChangesAsync();

        return Results.Ok(articles);
    }
    return Results.NotFound();
});

app.MapDelete("/articles/{id}", async (AppDbContext db, int id) =>
{
    var articles = await db.Articles.FindAsync(id);

    if (articles != null)
    {
        db.Remove(articles);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();

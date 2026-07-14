using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Patterns;
using PersonalBloggingPlatformAPI.Data;
using PersonalBloggingPlatformAPI.Models;

namespace PersonalBloggingPlatformAPI
{
    public class ArticleEndpoints
    {
        public static RouteGroupBuilder routeGroupBuilder(WebApplication app)
        {
            var group = app.MapGroup("/articles");

            group.MapPost("", async ([FromBody] Article article, AppDbContext db) =>
            {
                db.Articles.Add(article);
                await db.SaveChangesAsync();
                return Results.Ok(article);
            });

            group.MapGet("", async (AppDbContext db) =>
            {
                var articles = await db.Articles.ToListAsync();
                return Results.Ok(articles);
            });

            group.MapGet("/{id}", async (AppDbContext db, int id) =>
            {
                var article = await db.Articles.FindAsync(id);
                return article == null ? Results.NotFound() : Results.Ok(article);
            });

            group.MapPut("/{id}", async ([FromBody] Article updateArticle, AppDbContext db, int id) =>
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

            group.MapDelete("/{id}", async (AppDbContext db, int id) =>
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

            return group;
        }
    }
}

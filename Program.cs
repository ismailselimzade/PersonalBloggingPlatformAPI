using Microsoft.EntityFrameworkCore;

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
app.Run();

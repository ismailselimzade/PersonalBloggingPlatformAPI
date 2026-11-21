using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Models;

namespace PersonalBloggingPlatformAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("personal_blogging_platform_db");
        }
    }
}

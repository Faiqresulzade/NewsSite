using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using System.Reflection;
using NewsEntity = News.Domain.Entities.News;

namespace News.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(in DbContextOptions options) : base(options) { }

        DbSet<NewsCategory> NewsCategories { get; set; }
        DbSet<NewsEntity> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

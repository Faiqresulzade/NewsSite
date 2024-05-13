using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using System.Reflection;
using NewsEntity = News.Domain.Entities.News;

namespace News.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        private DbSet<NewsCategory> NewsCategories { get; set; }
        private DbSet<NewsEntity> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

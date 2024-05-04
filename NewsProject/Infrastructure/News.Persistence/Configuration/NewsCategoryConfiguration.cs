using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities;
using News.Persistence.Interfaces.Configuration;

namespace News.Persistence.Configuration
{
    /// <summary>
    /// Configuration class for the <see cref="NewsCategory"/> entity.
    /// </summary>
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>, ISeedData<NewsCategory>
    {

        /// <summary>
        /// Configures the entity type for the <see cref="NewsCategory"/> entity.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        /// 
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);

            builder.HasMany(nc => nc.News)
                  .WithOne(n => n.Category)
                  .HasForeignKey(n => n.CategoryId)
                  .OnDelete(DeleteBehavior.NoAction);

            AddSeedData(builder, 5);
        }

        /// <summary>
        /// Create seed data for the development environment
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="count"></param>
        public void AddSeedData(EntityTypeBuilder<NewsCategory> builder, int count)
        {
            Faker faker = new Faker();
            for (int i = 0; i < count; i++)
                builder.HasData(new NewsCategory()
                {
                    Name = faker.Commerce.Categories(1)[0],
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    Id = i + 1,
                });
        }
    }
}

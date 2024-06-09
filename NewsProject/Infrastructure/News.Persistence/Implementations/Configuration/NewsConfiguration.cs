using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Persistence.Bases.Interfaces.Configurations;
using NewsEntity = News.Domain.Entities.News;

namespace News.Persistence.Implementations.Configuration
{
    /// <summary>
    /// Configuration class for the <see cref="NewsEntity"/> entity.
    /// </summary>
    public class NewsConfiguration : IEntityTypeConfiguration<NewsEntity>, ISeedData<NewsEntity>
    {
        public void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.Property(n => n.AuthorName).HasMaxLength(50);
            builder.Property(n => n.Title).HasMaxLength(90);

            builder.HasOne(n => n.Category)
                .WithMany(nc => nc.News)
                .HasForeignKey(n => n.CategoryId);

            AddSeedData(builder, 4);
        }

        /// <summary>
        /// Create seed data for the development environment
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="count"></param>
        public void AddSeedData(EntityTypeBuilder<NewsEntity> builder, in int count)
        {
            Faker faker = new Faker();
            for (int i = 0; i < count; i++)
            {
                Random random = new Random();
                builder.HasData(new NewsEntity()
                {
                    Title = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    AuthorName = faker.Company.CompanyName(),
                    CategoryId = random.Next(1, 3),
                    ImagePath = faker.Commerce.ProductName(),
                    ReadCount = i * 5,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    Id = i + 1,
                });
            }
        }
    }
}

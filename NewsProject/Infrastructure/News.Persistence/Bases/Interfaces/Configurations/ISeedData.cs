using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Comman;

namespace News.Persistence.Bases.Interfaces.Configurations
{
    public interface ISeedData<T> where T : EntityBase, new()
    {
        public void AddSeedData(EntityTypeBuilder<T> builder, in int count);
    }
}

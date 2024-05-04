using News.Domain.Comman;

namespace News.Application.Abstraction.Interfaces.Factories
{
    public interface IFactory<T, Trequest> where T: class, IEntityBase, new()
    {
        public T Create(Trequest trequest);
    }
}

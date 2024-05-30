using News.Application.Bases.Interfaces.DI;

namespace News.Application.Bases.Interfaces.Rules
{
    public interface IBaseRule<Tentity> : IDependencyInjections
    {
        Tentity EntityNotFound(Tentity? category);
    }
}

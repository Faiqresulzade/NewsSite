using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Bases.Classes.Rules
{
    public abstract class BaseRules<Tentity> : IBaseRule<Tentity>
    {
        public abstract Tentity EntityNotFound(Tentity? entity);
    }
}
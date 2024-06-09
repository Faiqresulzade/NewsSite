using News.Application.Bases.Classes.Exceptions;
using News.Application.Bases.Interfaces.Rules;

namespace News.Application.Bases.Classes.Rules
{
    public class BaseRules<Tentity> : IBaseRule<Tentity>
    {
        public virtual Tentity EntityNotFound(Tentity? entity)
        {
            if (entity is not null)
                return entity;

            throw new EntityNotFoundException(typeof(Tentity).Name);
        }
    }
}
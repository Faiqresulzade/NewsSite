using News.Domain.Comman;

namespace News.Application.Abstraction.Interfaces.Factories
{
    /// <summary>
    /// Interface for a generic factory that creates instances of type T from request objects of type Trequest.
    /// </summary>
    /// <typeparam name="T">The type of object to be created.</typeparam>
    /// <typeparam name="Trequest">The type of the request object used for creating the object.</typeparam>
    public interface IFactory<Tentity, Trequest> where Tentity : class, IEntityBase, new()
    {
        /// <summary>
        /// Creates a new instance of type T based on the provided request object.
        /// </summary>
        /// <param name="trequest">The request object containing data for creating the object.</param>
        /// <returns>A newly created instance of type T.</returns>
        //T Create(Trequest trequest);

        public Task<Tentity> Create(Trequest trequest);
    }
}

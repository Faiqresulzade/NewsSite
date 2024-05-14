namespace News.Application.Bases.Interfaces.Singleton
{
    /// <summary>
    /// Base interface for classes implementing the singleton pattern,
    /// ensuring that only one instance of a class is created and providing global access to that instance.
    /// </summary>
    /// <typeparam name="T">The type of the class implementing the singleton pattern.</typeparam>
    public interface ISingletonBase<T>
    {
        /// <summary>
        /// Gets the singleton instance of the class.
        /// </summary>
        public static T Instance { get; }
    }
}

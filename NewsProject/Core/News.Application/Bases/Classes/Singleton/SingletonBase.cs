using News.Application.Bases.Interfaces.Singleton;

namespace News.Application.Bases.Classes.Singleton
{
    /// <summary>
    /// Base class for implementing the singleton pattern,
    /// ensuring that only one instance of a class is created and providing global access to that instance.
    /// </summary>
    /// <typeparam name="T">The type of the class inheriting from SingletonBase.</typeparam>

    public abstract class SingletonBase<T> : ISingletonBase<T> where T : class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance => _instance.Value;

        protected SingletonBase() { }
    }
}
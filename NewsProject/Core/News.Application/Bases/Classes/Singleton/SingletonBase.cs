using News.Application.Bases.Interfaces.Singleton;

namespace News.Application.Bases.Classes.Singleton
{
    public abstract class SingletonBase<T> : ISingletonBase<T> where T : class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance => _instance.Value;

        protected SingletonBase() { }
    }

}
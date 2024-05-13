namespace News.Application.Bases.Interfaces.Singleton
{
    public interface ISingletonBase<T> 
    {
       public static T Instance { get; }
    }
}

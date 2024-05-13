namespace News.Application.Abstraction.Interfaces.AutoMapper
{
    /// <summary>
    /// interface for custom IMapper
    /// </summary>
    public interface IMapper 
    {
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null);
        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null);
        public TDestination Map<TDestination>(object source, string? ignore = null);
        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);
    }
}

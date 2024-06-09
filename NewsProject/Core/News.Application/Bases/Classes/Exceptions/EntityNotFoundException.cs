namespace News.Application.Bases.Classes.Exceptions
{
    public class EntityNotFoundException : BaseExceptions
    {
        public EntityNotFoundException(string entityName) : base($"Bele {entityName} mövcud deyil") { }
    }
}

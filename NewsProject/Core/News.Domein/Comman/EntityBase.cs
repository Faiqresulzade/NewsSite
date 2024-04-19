namespace News.Domain.Comman
{
    /// <summary>
    /// Base class for entities in the domain.
    /// </summary>
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }//init
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}

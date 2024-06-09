namespace News.Domain.Comman
{
    public interface IEntityBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

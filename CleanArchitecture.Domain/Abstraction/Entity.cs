namespace CleanArchitecture.Domain.Abstraction
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

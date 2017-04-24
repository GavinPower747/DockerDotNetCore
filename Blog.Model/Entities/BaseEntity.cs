namespace Blog.Model.Entities
{
    public class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
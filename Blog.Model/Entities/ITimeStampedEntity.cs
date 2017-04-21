using System;

namespace Blog.Model.Entities
{
    public interface ITimeStampedEntity<TKey> : IEntity<TKey>
    {
        DateTime Created { get; set; }
        DateTime LastModified { get; set;}
    }
}
using System;
using Blog.Model.Entities;

namespace Blog.Model.Posts
{
    public class Post : ITimeStampedEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
    }
}
using System;
using Blog.Model.Entities;

namespace Blog.Model.Posts
{
    public class Post : BaseEntity<Guid>, ITimeStampedEntity<Guid>
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
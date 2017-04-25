using System;

namespace Blog.Services.Contracts.Posts
{
    public class CreatePostResponse
    {
        public Guid PostId { get; set; }
        public CreatePostResult Result { get; set; }
    }
}
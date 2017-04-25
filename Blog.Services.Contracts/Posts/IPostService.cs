using Blog.Model.Posts;
using System;
using System.Collections.Generic;

namespace Blog.Services.Contracts.Posts
{
    public interface IPostService
    {
        Post GetPost(Guid Id);
        IEnumerable<Post> GetAllPosts();
        CreatePostResponse InsertPost(Post post);
    }
}
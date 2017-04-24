using Blog.Model.Posts;
using System.Collections.Generic;

namespace Blog.Services.Contracts.Posts
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        CreatePostResult InsertPost(Post post);
    }
}
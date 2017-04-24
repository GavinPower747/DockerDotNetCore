using Blog.DataAccess.Contracts.Repositories;
using Blog.Model.Posts;
using Blog.Services.Contracts.Posts;
using System;
using System.Collections.Generic;

namespace Blog.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IRepository _repo;

        public PostService(IRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repo.GetAll<Post, Guid>();
        }

        public CreatePostResult InsertPost(Post post)
        {
            try
            {
                _repo.Create<Post, Guid>(post);
                return CreatePostResult.Success;
            }
            catch
            {
                return CreatePostResult.Failure;
            }
        }
    }
}
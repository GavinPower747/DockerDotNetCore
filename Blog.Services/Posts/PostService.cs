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

        public Post GetPost(Guid Id)
        {
            var post = _repo.Get<Post, Guid>(Id);

            if(post == null)
                throw new ArgumentException($"Could not find post with Id {Id}");
            
            return post;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repo.GetAll<Post, Guid>();
        }

        public CreatePostResponse InsertPost(Post post)
        {
            try
            {
                var savedEntity = _repo.Create<Post, Guid>(post);
                return new CreatePostResponse
                {
                    PostId = savedEntity.Id,
                    Result = CreatePostResult.Success   
                };
            }
            catch
            {
                return new CreatePostResponse
                {
                    Result = CreatePostResult.Failure   
                };
            }
        }
    }
}
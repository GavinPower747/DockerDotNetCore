using Blog.DataAccess.Contracts.Repositories;
using Blog.Model.Posts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Blog.MVC.Controllers
{
    public class BlogController
    {
        private readonly IRepository _repo;

        public BlogController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _repo.GetAll<Post, Guid>();
        }

        [HttpPost]
        public void Post([FromBody] Post entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Put([FromBody] Post entity)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void Delete([FromBody] Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
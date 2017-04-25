using Blog.Model.Posts;
using Blog.MVC.Settings;
using Blog.MVC.ViewModels;
using Blog.Services.Contracts.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace Blog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var posts = _postService.GetAllPosts();
            var viewModel = new BlogViewModel
            {
                Posts = posts
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            var response = _postService.InsertPost(post);

            if(response.Result == CreatePostResult.Failure)
                return BadRequest();
            
            return Created($"/Edit/{response.PostId}", post);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var response = _postService.GetPost(Id);

            return View(response);
        }
    }
}
using Blog.MVC.Settings;
using Blog.MVC.ViewModels;
using Blog.Services.Contracts.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
    }
}
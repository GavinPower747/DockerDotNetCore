using Blog.Model.Posts;
using System.Collections.Generic;

namespace Blog.MVC.ViewModels
{
    public class BlogViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
using System;

namespace Blog.MVC.Controllers
{
    public class ExceptionController
    {
        public void Index()
        {
            throw new Exception("This was meant to happen");
        }
    }
}
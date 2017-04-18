using Microsoft.AspNetCore.Mvc;

namespace TestMvcApp.Controllers
{
    public class HomeController
    {
        [HttpGet]
        public string Index(string message)
        {
            return "Hello world from a docker container";
        }
    }
}
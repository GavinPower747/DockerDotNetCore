using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TestMvcApp.Controllers
{
    public class HomeController
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string Index(string message)
        {
            return _config["Strings:ReturnMessage"];
        }
    }
}
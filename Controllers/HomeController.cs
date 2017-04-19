using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TestMvcApp.Controllers
{
    public class HomeController
    {
        private readonly IOptions<Strings> _config;

        public HomeController(IOptions<Strings> config)
        {
            _config = config;
        }

        [HttpGet]
        public string Index(string message)
        {
            return _config.Value.ReturnMessage;
        }
    }
}
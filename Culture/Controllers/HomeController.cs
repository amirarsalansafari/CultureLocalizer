using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Culture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        [HttpPost("[action]")]
        public IActionResult HelloWorld()
        {
            var message = _localizer["HelloWorldMessage"];
            return Ok(new { message });
        }
    }
}

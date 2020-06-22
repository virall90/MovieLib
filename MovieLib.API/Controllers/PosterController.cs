using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MovieLib.API.Controllers
{
    [Route("api/[controller]")]
    public class PostersController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public PostersController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        [HttpGet("{movieId?}")]
        public IActionResult Get([FromRoute] string movieId)
        {
            if (string.IsNullOrEmpty(movieId))
                return NotFound();
            
            var filePath = _webHostEnvironment.ContentRootPath + _configuration["PostersPath"] + movieId;
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var file = System.IO.File.OpenRead(filePath);
            return File(file, "image/jpeg");
        }
    }
}
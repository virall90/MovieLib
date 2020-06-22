using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MovieLib.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiConfigurationController : ControllerBase
    {
        private IConfiguration _configuration;

        public ApiConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string GetApiUrl() => _configuration["Api:Url"];
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLib.BL.Users.UserGetInfo;
using MovieLib.BL.Users.UserLogin;
using MovieLib.BL.Users.UserLogout;
using MovieLib.BL.Users.UserRegister;

namespace MovieLib.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserRegisterHandler _userRegisterHandler;
        private readonly UserLoginHandler _userLoginHandler;
        private readonly UserLogoutHandler _userLogoutHandler;
        private readonly UserGetInfoHandler _userGetInfoHandler;

        public UserController(
            UserRegisterHandler userRegisterHandler,
            UserLoginHandler userLoginHandler,
            UserLogoutHandler userLogoutHandler,
            UserGetInfoHandler userGetInfoHandler)
        {
            _userRegisterHandler = userRegisterHandler;
            _userLoginHandler = userLoginHandler;
            _userLogoutHandler = userLogoutHandler;
            _userGetInfoHandler = userGetInfoHandler;
        }

        [HttpPost]
        public async Task<UserLoginResponse> Login([FromBody] UserLoginCommand command)
        {
            return await _userLoginHandler.Handle(command);
        }

        [HttpPost]
        public async Task<UserLogoutResponse> Logout([FromBody] UserLogoutCommand command)
        {
            return await _userLogoutHandler.Handle(command);
        }

        [HttpPost]
        public async Task<UserRegisterResponse> Register([FromBody] UserRegisterCommand command)
        {
            return await _userRegisterHandler.Handle(command);
        }

        [HttpPost]
        public async Task<UserGetInfoResponse> GetInfo([FromBody] UserGetInfoQuery query)
        {
            return await _userGetInfoHandler.Handle(query);
        }
    }
}
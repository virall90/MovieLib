using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLib.BL.Common.Exceptions;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;

namespace MovieLib.BL.Users.UserLogout
{
    public class UserLogoutHandler : ICommandHandler<UserLogoutCommand, UserLogoutResponse>
    {
        private readonly MovieLibContext _movieLibContext;

        public UserLogoutHandler(MovieLibContext movieLibContext)
        {
            _movieLibContext = movieLibContext;
        }

        public async Task<UserLogoutResponse> Handle(UserLogoutCommand input)
        {
            var token = await _movieLibContext.UserApiTokens.FirstOrDefaultAsync(t => t.ApiToken == input.Token);
            if(token == null)
                throw new NotFoundException("Такого токена не существует");

            _movieLibContext.UserApiTokens.Remove(token);
            await _movieLibContext.SaveChangesAsync();

            return new UserLogoutResponse();
        }
    }
}
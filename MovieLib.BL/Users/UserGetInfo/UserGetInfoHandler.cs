using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieLib.BL.Common.Exceptions;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;
using MovieLib.Data.Models;

namespace MovieLib.BL.Users.UserGetInfo
{
    public class UserGetInfoHandler : IQueryHandler<UserGetInfoQuery, UserGetInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly MovieLibContext _movieLibContext;

        public UserGetInfoHandler(IMapper mapper, MovieLibContext movieLibContext)
        {
            _mapper = mapper;
            _movieLibContext = movieLibContext;
        }

        public async Task<UserGetInfoResponse> Handle(UserGetInfoQuery input)
        {
            var token = await _movieLibContext.UserApiTokens.Include(apiToken => apiToken.User)
                .FirstOrDefaultAsync(apiToken => apiToken.ApiToken == input.Token);
            
            if(token == null)
                throw new AuthenticationException("Такого токена нет");
            
            if(UserApiToken.IsExpired.IsSatisfiedBy(token))
                throw new AuthenticationException("Токен истек");

            var user = token.User;
            if (user == null)
                throw new NotFoundException("Пользователь не найден");

            var response = _mapper.Map<UserGetInfoResponse>(user);

            return response;
        }
    }
}
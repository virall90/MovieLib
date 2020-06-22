using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using MovieLib.BL.Common.Exceptions;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;
using MovieLib.Data.Models;

namespace MovieLib.BL.Users.UserLogin
{
    public class UserLoginHandler : ICommandHandler<UserLoginCommand, UserLoginResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly MovieLibContext _movieLibContext;

        public UserLoginHandler(UserManager<User> userManager, MovieLibContext movieLibContext)
        {
            _userManager = userManager;
            _movieLibContext = movieLibContext;
        }

        public async Task<UserLoginResponse> Handle(UserLoginCommand input)
        {
            await new UserLoginCommandValidator().ValidateAndThrowAsync(input);
            
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null)
                throw new AuthenticationException("Неверный email или пароль");

            var isPasswordOk = await _userManager.CheckPasswordAsync(user, input.Password);

            if (!isPasswordOk)
            {
                var identityResult = await _userManager.AccessFailedAsync(user);
                throw !identityResult.Succeeded
                    ? (Exception) new IdentityResultException(identityResult)
                    : new AuthenticationException("Неверный email или пароль");
            }

            var expiredTokens = _movieLibContext.UserApiTokens.Where(UserApiToken.IsExpired);

            _movieLibContext.UserApiTokens.RemoveRange(expiredTokens);
            await _movieLibContext.SaveChangesAsync();

            var newToken = new UserApiToken
            {
                UserId = user.Id,
                ExpirationDateTime = input.RememberMe ? (DateTime?) null : DateTime.Now.AddDays(1)
            };

            await _movieLibContext.UserApiTokens.AddAsync(newToken);
            await _movieLibContext.SaveChangesAsync();

            return new UserLoginResponse {Token = newToken.ApiToken};
        }
    }
}
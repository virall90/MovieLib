using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieLib.BL.Common.Exceptions;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;
using MovieLib.Data.Models;

namespace MovieLib.BL.Users.UserRegister
{
    public class UserRegisterHandler : ICommandHandler<UserRegisterCommand, UserRegisterResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly MovieLibContext _movieLibContext;


        public UserRegisterHandler(UserManager<User> userManager, IMapper mapper, MovieLibContext movieLibContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _movieLibContext = movieLibContext;
        }

        public async Task<UserRegisterResponse> Handle(UserRegisterCommand input)
        {
            await new UserRegisterCommandValidator().ValidateAndThrowAsync(input);

            var user = _mapper.Map<User>(input);

            if (string.IsNullOrEmpty(user.UserName))
                user.UserName = new string(user.Email.TakeWhile(c => c != '@').ToArray());

            var identityResult = await _userManager.CreateAsync(user, input.Password);

            if (!identityResult.Succeeded)
                throw new IdentityResultException(identityResult);

            user.ApiTokens = new List<UserApiToken>
            {
                new UserApiToken {ExpirationDateTime = DateTime.UtcNow.AddDays(1)}
            };
            await _userManager.UpdateAsync(user);

            var token = await _movieLibContext.UserApiTokens.FirstOrDefaultAsync(apiToken =>
                apiToken.UserId == user.Id);

            return new UserRegisterResponse {Token = token.ApiToken};
        }
    }
}
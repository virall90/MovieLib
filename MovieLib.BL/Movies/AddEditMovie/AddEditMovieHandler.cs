using System;
using System.IO;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieLib.BL.Common.Exceptions;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;
using MovieLib.Data.Models;

namespace MovieLib.BL.Movies.AddEditMovie
{
    public class AddEditMovieHandler : ICommandHandler<AddEditMovieCommand, AddEditMovieResponse>
    {
        private readonly IMapper _mapper;
        private readonly MovieLibContext _movieLibContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public AddEditMovieHandler(IMapper mapper, MovieLibContext movieLibContext,
            IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _mapper = mapper;
            _movieLibContext = movieLibContext;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public async Task<AddEditMovieResponse> Handle(AddEditMovieCommand input)
        {
            await new AddEditMovieCommandValidator().ValidateAndThrowAsync(input);

            var token = await _movieLibContext.UserApiTokens.Include(apiToken => apiToken.User)
                .FirstOrDefaultAsync(apiToken => apiToken.ApiToken == input.Token);

            if (token == null)
                throw new AuthenticationException("Такого токена нет");

            if (UserApiToken.IsExpired.IsSatisfiedBy(token))
                throw new AuthenticationException("Токен истек");

            var user = token.User;
            if (user == null)
                throw new NotFoundException("Пользователь не найден");

            Movie movie;
            if (input.Id == null)
            {
                movie = _mapper.Map<Movie>(input);
                movie.Id = Guid.NewGuid().ToString();
                movie.CreatedByUserId = user.Id;
                movie.HavePoster = input.PosterFile != null;

                await _movieLibContext.Movies.AddAsync(movie);
                await _movieLibContext.SaveChangesAsync();
            }
            else
            {
                movie = await _movieLibContext.Movies.FirstOrDefaultAsync(m => m.Id == input.Id);
                if (movie == null)
                    throw new NotFoundException("Фильм не найден");
                if (movie.CreatedByUserId != user.Id)
                    throw new AuthorizationException(
                        "Этот фильм создан другим пользователем, вам запрещено его изменять");

                movie = _mapper.Map(input, movie);
                movie.HavePoster = input.PosterFile != null;

                _movieLibContext.Movies.Update(movie);
                await _movieLibContext.SaveChangesAsync();
            }

            var posterDirectoryPath = _webHostEnvironment.ContentRootPath + _configuration["PostersPath"];
            if (!Directory.Exists(posterDirectoryPath))
                Directory.CreateDirectory(posterDirectoryPath);

            if (input.PosterFile != null)
            {
                await using var fileStream = new FileStream(
                    posterDirectoryPath + movie.Id,
                    FileMode.Create);
                await input.PosterFile.CopyToAsync(fileStream);
            }
            else if (input.Id != null)
            {
                var filePath = posterDirectoryPath + movie.Id;
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }


            return new AddEditMovieResponse();
        }
    }
}
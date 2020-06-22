#nullable enable
using Microsoft.AspNetCore.Http;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data.Models;

namespace MovieLib.BL.Movies.AddEditMovie
{
    /// <summary> Команда добавления или редактирования фильма </summary>
    public class AddEditMovieCommand : ICommand<AddEditMovieResponse>, IMapTo<Movie>
    {
        /// <summary> Токен API </summary>
        public string? Token { get; set; }

        /// <summary> Идентификатор </summary>
        public string? Id { get; set; }

        /// <summary> Название </summary>
        public string? Name { get; set; }

        /// <summary> Описание </summary>
        public string? Description { get; set; }

        /// <summary> Год выпуска </summary>
        public int? ReleaseYear { get; set; }

        /// <summary> Режиссёр </summary>
        public string? Director { get; set; }

        /// <summary> Название файла постера фильма </summary>
        public IFormFile? PosterFile { get; set; }
    }
}
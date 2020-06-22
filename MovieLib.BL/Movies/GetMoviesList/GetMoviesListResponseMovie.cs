using MovieLib.BL.Common.Interfaces;
using MovieLib.Data.Models;

namespace MovieLib.BL.Movies.GetMoviesList
{
    /// <summary> Модель фильма для запроса по получению списка фильмов </summary>
    public class GetMoviesListResponseMovie : IMapFrom<Movie>
    {
        /// <summary> Идентификатор </summary>
        public string Id { get; set; }

        /// <summary> Название </summary>
        public string Name { get; set; }

        /// <summary> Описание </summary>
        public string Description { get; set; }

        /// <summary> Год выпуска </summary>
        public int ReleaseYear { get; set; }

        /// <summary> Режиссёр </summary>
        public string Director { get; set; }

        /// <summary> Название файла постера фильма </summary>
        public bool HavePoster { get; set; }

        /// <summary> Создано пользователем </summary>
        public virtual GetMoviesListResponseMovieUser CreatedByUser { get; set; }
    }
}
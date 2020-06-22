using MovieLib.BL.Common.Interfaces;
using MovieLib.Data.Models;

namespace MovieLib.BL.Movies.GetMoviesList
{
    /// <summary> Модель пользователя для запроса по получению списка фильмов </summary>
    public class GetMoviesListResponseMovieUser : IMapFrom<User>
    {
        /// <summary> Идентификатор </summary>
        public string Id { get; set; }

        /// <summary> Имя пользователя </summary>
        public string UserName { get; set; }
    }
}
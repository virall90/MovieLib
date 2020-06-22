using MovieLib.BL.Common.Interfaces;
using MovieLib.Data.Models;

namespace MovieLib.BL.Movies.GetMovieById
{
    /// <summary> Модель пользователя для запроса по получению информации о фильм </summary>
    public class GetMovieByIdResponseUser : IMapFrom<User>
    {
        /// <summary> Идентификатор </summary>
        public string Id { get; set; }

        /// <summary> Имя пользователя </summary>
        public string UserName { get; set; }
    }
}
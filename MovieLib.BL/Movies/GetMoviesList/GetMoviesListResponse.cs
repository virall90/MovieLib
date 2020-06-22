using System.Collections.Generic;

namespace MovieLib.BL.Movies.GetMoviesList
{
    /// <summary> Ответ на запрос по получению списка фильмов </summary>
    public class GetMoviesListResponse
    {
        /// <summary> Список фильмов </summary>
        public List<GetMoviesListResponseMovie> MovieList { get; set; }
        
        /// <summary> Общее количество фильмов </summary>
        public int TotalCount { get; set; }
    }
}
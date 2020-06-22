using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Movies.GetMoviesList
{
    /// <summary> Запрос по получению списка фильмов </summary>
    public class GetMoviesListQuery : IPaginationQuery<GetMoviesListResponse>, ISearchTextQuery<GetMoviesListResponse>
    {
        /// <inheritdoc/>
        public int SkipCount { get; set; }
        /// <inheritdoc/>
        public int TakeCount { get; set; }
        /// <inheritdoc/>
        public string SearchText { get; set; }
    }
}
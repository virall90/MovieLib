using MovieLib.BL.Common.Interfaces;

namespace MovieLib.BL.Movies.GetMovieById
{
    /// <summary> Запрос по получению информации о фильме </summary>
    public class GetMovieByIdQuery: IQuery<GetMovieByIdResponse>
    {
        /// <summary> Идентификатор </summary>
        public string MovieId { get; set; }
    }
}
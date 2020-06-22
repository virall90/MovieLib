using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLib.BL.Movies.AddEditMovie;
using MovieLib.BL.Movies.GetMovieById;
using MovieLib.BL.Movies.GetMoviesList;

namespace MovieLib.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MoviesController : Controller
    {
        private readonly AddEditMovieHandler _addEditMovieCommandHandler;
        private readonly GetMoviesListHandler _getMoviesListHandler;
        private readonly GetMovieByIdHandler _getMovieByIdHandler;

        public MoviesController(AddEditMovieHandler addEditMovieCommandHandler,
            GetMoviesListHandler getMoviesListHandler, GetMovieByIdHandler getMovieByIdHandler)
        {
            _addEditMovieCommandHandler = addEditMovieCommandHandler;
            _getMoviesListHandler = getMoviesListHandler;
            _getMovieByIdHandler = getMovieByIdHandler;
        }

        [HttpPost]
        public async Task<AddEditMovieResponse> AddEditMovie([FromForm] AddEditMovieCommand command)
        {
            return await _addEditMovieCommandHandler.Handle(command);
        }

        [HttpPost]
        public async Task<GetMovieByIdResponse> GetMovieById([FromBody] GetMovieByIdQuery query)
        {
            return await _getMovieByIdHandler.Handle(query);
        }

        [HttpPost]
        public async Task<GetMoviesListResponse> GetMoviesList([FromBody] GetMoviesListQuery query)
        {
            return await _getMoviesListHandler.Handle(query);
        }
    }
}
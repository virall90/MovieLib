using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;

namespace MovieLib.BL.Movies.GetMoviesList
{
    public class GetMoviesListHandler : IQueryHandler<GetMoviesListQuery, GetMoviesListResponse>
    {
        private readonly MovieLibContext _movieLibContext;
        private readonly IMapper _mapper;

        public GetMoviesListHandler(MovieLibContext movieLibContext, IMapper mapper)
        {
            _movieLibContext = movieLibContext;
            _mapper = mapper;
        }

        public async Task<GetMoviesListResponse> Handle(GetMoviesListQuery input)
        {
            var moviesQuery = _movieLibContext.Movies
                .Include(movie => movie.CreatedByUser)
                .Where(
                    movie => input.SearchText == null ||
                             (movie.Id+movie.Name+movie.Description+movie.ReleaseYear.ToString()+movie.Director)
                                 .ToLower().Contains(input.SearchText.ToLower())
                );
            
            return new GetMoviesListResponse()
            {
                MovieList = await moviesQuery.Skip(input.SkipCount).Take(input.TakeCount)
                    .ProjectTo<GetMoviesListResponseMovie>(_mapper.ConfigurationProvider).ToListAsync(),
                TotalCount = await moviesQuery.CountAsync()
            };
        }
    }
}
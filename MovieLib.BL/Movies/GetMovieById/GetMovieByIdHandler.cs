using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MovieLib.BL.Common.Interfaces;
using MovieLib.Data;

namespace MovieLib.BL.Movies.GetMovieById
{
    public class GetMovieByIdHandler : IQueryHandler<GetMovieByIdQuery, GetMovieByIdResponse>
    {
        private readonly MovieLibContext _movieLibContext;
        private readonly IMapper _mapper;

        public GetMovieByIdHandler(MovieLibContext movieLibContext, IMapper mapper)
        {
            _movieLibContext = movieLibContext;
            _mapper = mapper;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery input)
        {
            return await _movieLibContext.Movies
                .Include(m => m.CreatedByUser)
                .Where(m => m.Id == input.MovieId)
                .ProjectTo<GetMovieByIdResponse>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
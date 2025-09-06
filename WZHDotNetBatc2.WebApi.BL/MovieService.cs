using System.Threading.Tasks;
using WZHDotNetBatc2.DataAccess;
using WZHDotNetBatc2.Database.AppDbContextModels;

namespace WZHDotNetBatc2.WebApi.BL
{
    public class MovieService
    {
        private readonly MovieDataAccess _movieDataAccess;

        public MovieService(MovieDataAccess movieDataAccess)
        {
            _movieDataAccess = movieDataAccess;
        }
        public async Task<List<TblMovie>> GetMovies(int PageNo, int PageSize)
        {
            if (PageNo == 0 && PageSize == 0)
            {
                throw new ArgumentException("Page number or page size cannot be zero");
            }
            var lst = await _movieDataAccess.GetMoviesAsync(PageNo, PageSize);
            return lst;
        }
        public async Task<int>  CreateMovie(TblMovie movie)
        {
            if (movie is null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            int newMovie = await _movieDataAccess.CreateMovie(movie);
            return newMovie;
        }
        public async Task<int> UpdadeMovie(TblMovie movie)
        {
            if(movie.MovieId == 0)
            {
                throw new Exception("you cannot update movie");
            }
          int result =  await _movieDataAccess.UpdateMovie(movie);
            return result;
        }
        public async Task<int> DeleteMovie(int id) 
        {
            if (id == 0) 
            {
                throw new Exception("invalid id");
            }
            var deleteMovie = await _movieDataAccess.DeleteMovieAsync(id);
            return deleteMovie;
        }
    }
}

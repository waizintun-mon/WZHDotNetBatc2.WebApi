using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WZHDotNetBatc2.Database.AppDbContextModels;

namespace WZHDotNetBatc2.DataAccess
{
    public class MovieDataAccess
    {
        private readonly AppDbContext _db;

        public MovieDataAccess(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TblMovie>> GetMoviesAsync(int PageNo, int PageSize)
        {
            List<TblMovie> lst = await _db.TblMovies
                .Where(x => x.DeleteFlag == false)
                .Skip((PageNo - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync(); 
            return lst;
        }
        public async Task<int> CreateMovie( TblMovie movie)
        {
             var newMovie = new TblMovie()
              {
                  Title = movie.Title,
                  Genre = movie.Genre,
                  ReleaseYear = movie.ReleaseYear,
                  Rating = movie.Rating,
              };
                     await _db.TblMovies.AddAsync(newMovie);
           int result = await _db.SaveChangesAsync();
            return result;
        }
        public async Task<int> UpdateMovie(TblMovie movie)
        {
            var updateMovie = await _db.TblMovies.Where(x => x.DeleteFlag == false).FirstOrDefaultAsync(x => x.MovieId == movie.MovieId);
            if (updateMovie == null)
                throw new Exception("no movie found");
            updateMovie.Title = movie.Title;
            updateMovie.Genre = movie.Genre;
            updateMovie.ReleaseYear = movie.ReleaseYear;
            updateMovie.Rating = movie.Rating;
           int result = await _db.SaveChangesAsync();
            return result;  
        }
        public async Task<int> DeleteMovieAsync(int id)
        {
            var deleteMovie = await _db.TblMovies.FirstOrDefaultAsync(d=>d.MovieId == id);  
            if (deleteMovie == null)
                throw new Exception("No movie found");
            deleteMovie.DeleteFlag = true;
           int result =  await _db.SaveChangesAsync();
            return result;  
        }
    }
}

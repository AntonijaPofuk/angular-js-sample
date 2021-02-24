using AngularJsSample.Common;
using AngularJsSample.Model.MovieGenres;

namespace AngularJsSample.Model.MovieGenres
{
    public interface IMovieGenreRepository:IRepository<MovieGenre,int>
    {
        int AddMovieGenre(int genreId, int movieId);

    }
}
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MovieGenres;
using AngularJsSample.Services.Messaging.Views;

namespace AngularJsSample.Services
{
    public interface IMovieGenreService
    {
        GetMovieGenreResponse GetMovieGenre(GetMovieGenreRequest request);
        SaveMovieGenreResponse SaveMovieGenre(SaveMovieGenreRequest request);


    }
}
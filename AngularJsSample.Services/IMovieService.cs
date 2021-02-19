using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.Movies;
using AngularJsSample.Services.Messaging.Views;

namespace AngularJsSample.Services
{
    public interface IMovieService
    {
        GetMovieResponse GetMovie(GetMovieRequest request);
        GetMoviesResponse GetMovies(GetMoviesRequest request);
        DeleteMovieResponse DeleteMovie(DeleteMovieRequest request);
        SaveMovieResponse SaveMovie(SaveMovieRequest request);


    }
}
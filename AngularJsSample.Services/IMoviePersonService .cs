using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MoviePersons;
using AngularJsSample.Services.Messaging.Views;

namespace AngularJsSample.Services
{

    public interface IMoviePersonService
    {
        GetMoviePersonResponse GetMoviePerson(GetMoviePersonRequest request);
        GetMoviePersonsResponse GetMoviePersons(GetMoviePersonsRequest request);
        SaveMoviePersonResponse SaveMoviePerson(SaveMoviePersonRequest request);
        DeleteMoviePersonResponse DeleteMoviePerson(DeleteMoviePersonRequest request);

    }
}
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MovieRatings;
using AngularJsSample.Services.Messaging.Views;

namespace AngularJsSample.Services
{
    public interface IMovieRatingService
    {
        GetMovieRatingResponse GetMovieRating(GetMovieRatingRequest request);
        SaveMovieRatingResponse SaveMovieRating(SaveMovieRatingRequest request);


    }
}
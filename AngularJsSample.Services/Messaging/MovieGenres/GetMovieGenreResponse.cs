using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Services.Messaging.Views.MovieGenres;

namespace AngularJsSample.Services.Messaging.MovieGenres
{
    public class GetMovieGenreResponse : ResponseBase<GetMovieGenreRequest>
    {
        public MovieGenre MovieGenre { get; set; }
    }
}

using AngularJsSample.Services.Messaging.Views.MovieGenres;
using System.Collections.Generic;

namespace AngularJsSample.Services.Messaging.MovieGenres
{
    public class GetMovieGenreResponse : ResponseBase<GetMovieGenreRequest>
    {
        public List<MovieGenre> MovieGenres { get; set; }
    }
}

using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Services.Messaging.Views.MovieGenres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging.MovieGenres
{
    public class SaveMovieGenreResponse : ResponseBase<SaveMovieGenreRequest>
    {
        public MovieGenre MovieGenre { get; set; }

    }
}

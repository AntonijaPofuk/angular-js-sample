using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Services.Messaging.Views.MovieGenres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging
{
    public class SaveMovieGenreRequest:RequestBase
    {
        public MovieGenre MovieGenre { get; set; }
    }
}

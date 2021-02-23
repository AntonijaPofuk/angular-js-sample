using AngularJsSample.Services.Messaging.Views.Genres;
using AngularJsSample.Services.Messaging.Views.Movies;
using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging.Views.MovieGenres
{
    public class MovieGenre
    {
        public Movie MovieId { get; set; }
        public Genre GenreId { get; set; }
       
    }
}

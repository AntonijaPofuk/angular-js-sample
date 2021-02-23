using AngularJsSample.Model.Genres;
using AngularJsSample.Model.Movies;
using AngularJsSample.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Model.MovieGenres
{
    public class MovieGenre
    {
        public Movie MovieId { get; set; }
        public Genre GenreId { get; set; }    

    }
}

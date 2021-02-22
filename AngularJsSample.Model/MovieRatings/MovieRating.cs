using AngularJsSample.Model.Genres;
using AngularJsSample.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Model.MovieRatings
{
    public class MovieRating
    {


        public int MovieId { get; set; }
        public int UserRatedId { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public int Rating { get; set; }


    }
}

using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging.Views.MovieRatings
{
    public class MovieRating
    {
        public int MovieId { get; set; }
        public int UserRatedId { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
    }
}

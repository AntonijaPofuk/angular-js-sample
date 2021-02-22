using AngularJsSample.Services.Messaging.Views.MovieRatings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging
{
    public class SaveMovieRatingRequest:RequestBase
    {
        public MovieRating MovieRating { get; set; }
    }
}

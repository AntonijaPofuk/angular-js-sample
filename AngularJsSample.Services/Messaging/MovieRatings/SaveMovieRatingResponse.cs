﻿using AngularJsSample.Services.Messaging.Views.MovieRatings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging.MovieRatings
{
    public class SaveMovieRatingResponse : ResponseBase<SaveMovieRatingRequest>
    {
        public MovieRating MovieRating { get; set; }

    }
}

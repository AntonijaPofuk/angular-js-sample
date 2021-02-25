using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsSample.Services.Messaging.Views.MovieRatings;
using AngularJsSample.Api.Models;
using AngularJsSample.Api.Mapping.Users;

namespace AngularJsSample.Api.Mapping.MovieRatings
{
    public static class MovieRatingsMapper
    {
        /// <summary>
        /// Maps Messaging.Views.MovieRating into MovieRating.ViewModel 
        /// </summary>
        /// <param name="view">Messaging.Views.MovieRating</param>
        /// <returns>Messaging.Views.MovieRating</returns>
        public static MovieRatingViewModel MapToViewModel(this MovieRating view)
        {
            if (view == null)
                return null;
            return new MovieRatingViewModel()
            {
                MovieId = view.MovieId,
                UserRatedId = view.UserRatedId,
                Datecreated = view.DateCreated,
                Rating = view.Rating,
                UserCreated = view.UserCreated.MapToViewModel()
            };
        }

        /// <summary>
        /// Maps Api.Models.MovieRatingViewModel into Messaging.Views.MovieRating
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns> Messaging.Views.MovieRating</returns>
        public static MovieRating MapToView(this MovieRatingViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new MovieRating()
            {
                MovieId = viewModel.MovieId,
                UserRatedId = viewModel.UserRatedId,
                DateCreated = viewModel.Datecreated,
                Rating = viewModel.Rating,
                UserCreated = viewModel.UserCreated.MapToView()
            };
        }
      
    }
}
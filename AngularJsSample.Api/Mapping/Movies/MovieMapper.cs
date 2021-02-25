using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsSample.Services.Messaging.Views.Movies;
using AngularJsSample.Api.Models;
using AngularJsSample.Api.Mapping.Users;

namespace AngularJsSample.Api.Mapping.Movies
{
    public static class MoviesMapper
    {
        /// <summary>
        /// Maps Messaging.Views.Movie into MovieViewModel for FK values
        /// </summary>
        /// <param name="view">Messaging.Views.Movie</param>
        /// <returns>MovieViewModel</returns>
        public static MovieViewModel MapToViewModelFK(this Movie view)
        {
            if (view == null)
                return null;
            return new MovieViewModel()
            {
                Id = view.Id,
                Name = view.Name
            };
        }

        /// <summary>
        /// Maps Messaging.Views.Movie into Api.ModelsMovieViewModel 
        /// </summary>
        /// <param name="view">Messaging.Views.Movie</param>
        /// <returns>MovieViewModel</returns>
        public static MovieViewModel MapToViewModel(this Movie view)
        {
            if (view == null)
                return null;
            return new MovieViewModel()
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,               
                Datecreated = view.DateCreated,
                UserLastModified = view.UserLastModified.MapToViewModel(),
                UserCreated = view.UserCreated.MapToViewModel(),
                Rating = view.Rating,
                PosterUrl = view.PosterUrl,
                IMDBUrl = view.IMDBUrl,
                ReleaseDate = view.ReleaseDate,
                Genres = null
            };
        }

        /// <summary>
        /// Maps Api.Models.MovieViewModel into  Messaging.Views.Movie
        /// </summary>
        /// <param name="viewModel">Api.Models.MovieViewModel</param>
        /// <returns> Messaging.Views.Movie</returns>
        public static Movie MapToView(this MovieViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new Movie()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,               
                DateCreated = viewModel.Datecreated,
                UserLastModified = viewModel.UserLastModified.MapToView(),
                UserCreated = viewModel.UserCreated.MapToView(),
                Rating = viewModel.Rating,
                PosterUrl = viewModel.PosterUrl,
                IMDBUrl = viewModel.IMDBUrl,
                ReleaseDate = viewModel.ReleaseDate,
                Genres = null

            };
        }

        /// <summary>
        /// Maps IEnumerable<Movie> into List<MovieViewModel>
        /// </summary>
        /// <param name="views">IEnumerable<Movie></param>
        /// <returns>List<MovieViewModel></returns>
        public static List<MovieViewModel> MapToViewModels(this IEnumerable<Movie> views)
        {
            var result = new List<MovieViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}
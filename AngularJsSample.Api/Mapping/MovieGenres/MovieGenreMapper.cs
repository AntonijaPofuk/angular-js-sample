using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsSample.Services.Messaging.Views.MovieGenres;
using AngularJsSample.Api.Models;
using AngularJsSample.Api.Mapping.Users;
using AngularJsSample.Api.Mapping.Genres;
using AngularJsSample.Api.Mapping.Movies;


namespace AngularJsSample.Api.Mapping.MovieGenres
{
    public static class MovieGenresMapper
    {
        /// <summary>
        /// Maps Messaging.Views.MovieGenre into Api.ModelsMovieGenreViewModel 
        /// </summary>
        /// <param name="view">Messaging.Views.MovieGenre</param>
        /// <returns>MovieGenreViewModel</returns>
        public static MovieGenreViewModel MapToViewModel(this MovieGenre view)
        {
            if (view == null)
                return null;
            return new MovieGenreViewModel()
            {
                GenreId = view.GenreId.MapToViewModelFK(),
                MovieId = view.MovieId.MapToViewModelFK()                         
            };
        }
        /// <summary>
        /// Maps Api.Models.MovieGenreViewModel into  Messaging.Views.MovieGenre
        /// </summary>
        /// <param name="viewModel">Api.Models.MovieGenreViewModel</param>
        /// <returns> Messaging.Views.MovieGenre</returns>

        public static MovieGenre MapToView(this MovieGenreViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new MovieGenre()
            {
                MovieId = viewModel.MovieId.MapToView(),
                GenreId = viewModel.GenreId.MapToView()

            };
        }
        /// <summary>
        /// Maps IEnumerable<MovieGenre> into List<MovieGenreViewModel>
        /// </summary>
        /// <param name="views">IEnumerable<MovieGenre></param>
        /// <returns>List<MovieGenreViewModel></returns>
        public static List<MovieGenreViewModel> MapToViewModels(this IEnumerable<MovieGenre> views)
        {
            var result = new List<MovieGenreViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}
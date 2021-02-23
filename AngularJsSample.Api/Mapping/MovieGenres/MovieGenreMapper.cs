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
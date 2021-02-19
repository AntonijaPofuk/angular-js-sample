﻿using System;
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
                UserCreated = view.UserCreated.MapToViewModel()
            };
        }

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
                UserCreated = viewModel.UserCreated.MapToView()
            };
        }

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
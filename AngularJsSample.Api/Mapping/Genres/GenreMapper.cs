using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsSample.Services.Messaging.Views.Genres;
using AngularJsSample.Api.Models;
using AngularJsSample.Api.Mapping.Users;

namespace AngularJsSample.Api.Mapping.Genres
{
    public static class GenresMapper
    {
        public static GenreViewModel MapToViewModel(this Genre view)
        {
            if (view == null)
                return null;
            return new GenreViewModel()
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,               
                Datecreated = view.DateCreated,
                UserLastModified = view.UserLastModified.MapToViewModel(),
                UserCreated = view.UserCreated.MapToViewModel()
            };
        }

        public static Genre MapToView(this GenreViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new Genre()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,               
                DateCreated = viewModel.Datecreated,
                UserLastModified = viewModel.UserLastModified.MapToView(),
                UserCreated = viewModel.UserCreated.MapToView()
            };
        }

        public static List<GenreViewModel> MapToViewModels(this IEnumerable<Genre> views)
        {
            var result = new List<GenreViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}
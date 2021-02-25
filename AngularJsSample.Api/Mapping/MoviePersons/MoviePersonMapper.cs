using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsSample.Services.Messaging.Views.MoviePersons;
using AngularJsSample.Api.Models;
using AngularJsSample.Api.Mapping.Users;

namespace AngularJsSample.Api.Mapping.MoviePersons
{
    public static class MoviePersonsMapper
    {
        /// <summary>
        /// Maps Messaging.Views.MoviePerson into Api.ModelsMoviePersonViewModel 
        /// </summary>
        /// <param name="view">Messaging.Views.MoviePerson</param>
        /// <returns>MoviePersonViewModel</returns>
        public static MoviePersonViewModel MapToViewModel(this MoviePerson view)
        {
            if (view == null)
                return null;
            return new MoviePersonViewModel()
            {
                Id = view.Id,
                Firstname = view.FirstName,
                Lastname = view.LastName,
                FullName = view.FullName,
                Birthplace = view.BirthPlace,
                Biography = view.Biography,
                Photourl = view.PhotoUrl,
                Popularity = view.Popularity,
                Birthday = view.Birthday,
                Datecreated = view.DateCreated,
                IMDBUrl = view.IMDBUrl,
                UserLastModified = view.UserLastModified.MapToViewModel(),
                UserCreated = view.UserCreated.MapToViewModel()
            };
        }

        /// <summary>
        /// Maps Api.Models.MoviePersonViewModel into  Messaging.Views.MoviePerson
        /// </summary>
        /// <param name="viewModel">Api.Models.MoviePersonViewModel</param>
        /// <returns> Messaging.Views.MoviePerson</returns>
        public static MoviePerson MapToView(this MoviePersonViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            return new MoviePerson()
            {
                Id = viewModel.Id,
                FirstName = viewModel.Firstname,
                LastName = viewModel.Lastname,
                FullName = viewModel.FullName,
                BirthPlace = viewModel.Birthplace,
                Biography = viewModel.Biography,
                PhotoUrl = viewModel.Photourl,
                Popularity = viewModel.Popularity,
                Birthday = viewModel.Birthday,
                DateCreated = viewModel.Datecreated,
                IMDBUrl = viewModel.IMDBUrl,
                UserLastModified = viewModel.UserLastModified.MapToView(),
                UserCreated = viewModel.UserCreated.MapToView()
            };
        }

        /// <summary>
        /// Maps IEnumerable<MoviePerson> into List<MoviePersonViewModel>
        /// </summary>
        /// <param name="views">IEnumerable<MoviePerson></param>
        /// <returns>List<MoviePersonViewModel></returns>
        public static List<MoviePersonViewModel> MapToViewModels(this IEnumerable<MoviePerson> views)
        {
            var result = new List<MoviePersonViewModel>();
            if (views == null)
                return result;
            result.AddRange(views.Select(item => item.MapToViewModel()));
            return result;
        }
    }
}


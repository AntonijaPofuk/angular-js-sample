using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.Genres;
using AngularJsSample.Services.Messaging.Views.MoviePersons;
using AngularJsSample.Services.Messaging.Views.Movies;
using AngularJsSample.Services.Messaging.Views.Users;
using AutoMapper;

namespace AngularJsSample.Services.Services.Mapping.Profiles
{
    public class CommonProfile: Profile
    {
        protected override void Configure()
        {
            //map from domain classes to views
            CreateMap<Model.Users.UserInfo, UserInfo>();
            CreateMap<Model.MoviePersons.MoviePerson, MoviePerson>();
            CreateMap<Model.Genres.Genre, Genre>();
            CreateMap<Model.Movies.Movie, Movie>();



            //map from views to domain classes
            CreateMap<UserInfo, Model.Users.UserInfo>();
            CreateMap<MoviePerson, Model.MoviePersons.MoviePerson>();
            CreateMap<Genre, Model.Genres.Genre>();
            CreateMap<Movie, Model.Movies.Movie>();


        }
    }
}

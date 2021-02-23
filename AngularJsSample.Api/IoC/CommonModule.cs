using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Model.MovieRatings;
using AngularJsSample.Model.Movies;
using AngularJsSample.Model.Users;
using AngularJsSample.Model.Genres;
using AngularJsSample.Repositories;
using AngularJsSample.Services;
using AngularJsSample.Services.Impl;
using Autofac;
using AngularJsSample.Model.MovieGenres;

namespace AngularJsSample.Api.IoC
{
    public class CommonModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<MoviePersonRepository>().As<IMoviePersonRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>();
            builder.RegisterType<MovieRatingRepository>().As<IMovieRatingRepository>();
            builder.RegisterType<MovieGenreRepository>().As<IMovieGenreRepository>();



            //services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MoviePersonService>().As<IMoviePersonService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<MovieService>().As<IMovieService>();
            builder.RegisterType<MovieRatingService>().As<IMovieRatingService>();
            builder.RegisterType<MovieGenreService>().As<IMovieGenreService>();

        }
    }
}
using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Model.Users;
using AngularJsSample.Model.Genres;
using AngularJsSample.Repositories;
using AngularJsSample.Services;
using AngularJsSample.Services.Impl;
using Autofac;

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

            //services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MoviePersonService>().As<IMoviePersonService>();
            builder.RegisterType<GenreService>().As<IGenreService>();


        }
    }
}
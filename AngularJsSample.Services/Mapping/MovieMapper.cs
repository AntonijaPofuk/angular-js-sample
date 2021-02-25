using AutoMapper;
using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.Movies;
using System.Collections.Generic;
using System.Linq;

namespace AngularJsSample.Services.Mapping
{
    public static class MoviesMapper
    {

        /// <summary>
        /// Maps Model.Movie.Movie into Messaging.Views.Movie.Movie
        /// </summary>
        /// <param name="model">Model.Movie.Movie</param>
        /// <returns>Messaging.Views.Movie.Movie</returns>

        public static Messaging.Views.Movies.Movie MapToView(this Model.Movies.Movie model)
        {
            return Mapper.Map<Messaging.Views.Movies.Movie>(model);
        }

        /// <summary>
        /// Maps Messaging.Views.Movie.Movie into Model.Movie.Movie
        /// </summary>
        /// <param name="view">Messaging.Views.Movie.Movie</param>
        /// <returns> Model.Movie.Movie</returns>

        public static Model.Movies.Movie MapToModel(this Messaging.Views.Movies.Movie view) {
            return Mapper.Map<Model.Movies.Movie>(view);

        }
        /// <summary>
        /// Maps Model.Movie.Movie into List of Messaging.Views.Movie.Movie
        /// </summary>
        /// <param name="models"></param>
        /// <returns>List of Messaging.Views.Movies.Movie </returns>

        public static List<Messaging.Views.Movies.Movie> MapToViews(this IEnumerable<Model.Movies.Movie> models)
        {
            var result = new List<Messaging.Views.Movies.Movie>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }

    }

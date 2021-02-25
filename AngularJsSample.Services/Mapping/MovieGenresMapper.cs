using AutoMapper;
using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.MovieGenres;
using System.Collections.Generic;
using System.Linq;

namespace AngularJsSample.Services.Mapping
{
    public static class MovieGenresMapper
    {

        /// <summary>
        /// Maps Model.MoviePerson.MovieGenre into Messaging.Views.MoviePerson.MovieGenre
        /// </summary>
        /// <param name="model">Model.MoviePerson.MovieGenre</param>
        /// <returns>Messaging.Views.MoviePerson.MovieGenre</returns>

        public static Messaging.Views.MovieGenres.MovieGenre MapToView(this Model.MovieGenres.MovieGenre model)
        {
            return Mapper.Map<Messaging.Views.MovieGenres.MovieGenre>(model);
        }

        /// <summary>
        /// Maps Messaging.Views.MoviePerson.MovieGenre into Model.MoviePerson.MovieGenre
        /// </summary>
        /// <param name="view">Messaging.Views.MoviePerson.MovieGenre</param>
        /// <returns> Model.MoviePerson.MovieGenre</returns>

        public static Model.MovieGenres.MovieGenre MapToModel(this Messaging.Views.MovieGenres.MovieGenre view) {
            return Mapper.Map<Model.MovieGenres.MovieGenre>(view);

        }

        /// <summary>
        /// Maps Model.MoviePerson.MovieGenre into List of Messaging.Views.MoviePerson.MovieGenre
        /// </summary>
        /// <param name="models"></param>
        /// <returns>List of Messaging.Views.MovieGenres.MovieGenre </returns>

        public static List<Messaging.Views.MovieGenres.MovieGenre> MapToViews(this IEnumerable<Model.MovieGenres.MovieGenre> models)
        {
            var result = new List<Messaging.Views.MovieGenres.MovieGenre>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }

    }

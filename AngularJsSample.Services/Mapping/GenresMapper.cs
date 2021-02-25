using AutoMapper;
using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.Genres;
using System.Collections.Generic;
using System.Linq;

namespace AngularJsSample.Services.Mapping
{
    public static class GenresMapper
    {

        /// <summary>
        /// Maps Model.Genre.Genre into Messaging.Views.Genre.Genre
        /// </summary>
        /// <param name="model">Model.Genre.Genre</param>
        /// <returns>Messaging.Views.Genre.Genre</returns>

        public static Messaging.Views.Genres.Genre MapToView(this Model.Genres.Genre model)
        {
            return Mapper.Map<Messaging.Views.Genres.Genre>(model);
        }

        /// <summary>
        /// Maps Messaging.Views.Genre.Genre into Model.Genre.Genre
        /// </summary>
        /// <param name="view">Messaging.Views.Genre.Genre</param>
        /// <returns> Model.Genre.Genre</returns>

        public static Model.Genres.Genre MapToModel(this Messaging.Views.Genres.Genre view) {
            return Mapper.Map<Model.Genres.Genre>(view);

        }
        /// <summary>
        /// Maps Model.Genre.Genre into List of Messaging.Views.Genre.Genre
        /// </summary>
        /// <param name="models"></param>
        /// <returns>List of Messaging.Views.Genres.Genre </returns>
        public static List<Messaging.Views.Genres.Genre> MapToViews(this IEnumerable<Model.Genres.Genre> models)
        {
            var result = new List<Messaging.Views.Genres.Genre>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }

    }

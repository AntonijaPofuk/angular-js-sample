using AutoMapper;
using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.MovieRatings;
using System.Collections.Generic;
using System.Linq;

namespace AngularJsSample.Services.Mapping
{
    public static class MovieRatingsMapper
    {

        /// <summary>
        /// Maps Model.MovieRatings.MovieRating into Messaging.Views.MovieRatings.MovieRating
        /// </summary>
        /// <param name="model">Model.MovieRatings.MovieRating</param>
        /// <returns>Messaging.Views.MovieRatings.MovieRating</returns>
        public static Messaging.Views.MovieRatings.MovieRating MapToView(this Model.MovieRatings.MovieRating model)
        {
            return Mapper.Map<Messaging.Views.MovieRatings.MovieRating>(model);
        }


        /// <summary>
        /// Maps Messaging.Views.MovieRatings.MovieRating into Model.MovieRatings.MovieRating
        /// </summary>
        /// <param name="view">Messaging.Views.MovieRatings.MovieRating</param>
        /// <returns> Model.MovieRatings.MovieRating</returns>
        public static Model.MovieRatings.MovieRating MapToModel(this Messaging.Views.MovieRatings.MovieRating view) {
            return Mapper.Map<Model.MovieRatings.MovieRating>(view);

        }
        /// <summary>
        /// Maps Model.MovieRatings.MovieRating into List of Messaging.Views.MovieRatings.MovieRating
        /// </summary>
        /// <param name="models"></param>
        /// <returns>List of Messaging.Views.MovieRatings.MovieRating </returns>
        public static List<Messaging.Views.MovieRatings.MovieRating> MapToViews(this IEnumerable<Model.MovieRatings.MovieRating> models)
        {
            var result = new List<Messaging.Views.MovieRatings.MovieRating>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }

    }

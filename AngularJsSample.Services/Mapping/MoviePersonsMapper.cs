using AutoMapper;
using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.MoviePersons;
using System.Collections.Generic;
using System.Linq;

namespace AngularJsSample.Services.Mapping
{
    public static class MoviePersonsMapper
    {

        /// <summary>
        /// Maps Model.MoviePerson.MoviePerson into Messaging.Views.MoviePerson.MoviePerson
        /// </summary>
        /// <param name="model">Model.MoviePerson.MoviePerson</param>
        /// <returns>Messaging.Views.MoviePerson.MoviePerson</returns>
        public static Messaging.Views.MoviePersons.MoviePerson MapToView(this Model.MoviePersons.MoviePerson model)
        {
            return Mapper.Map<Messaging.Views.MoviePersons.MoviePerson>(model);
        }

        /// <summary>
        /// Maps Messaging.Views.MoviePerson.MoviePerson into Model.MoviePerson.MoviePerson
        /// </summary>
        /// <param name="view">Messaging.Views.MoviePerson.MoviePerson</param>
        /// <returns> Model.MoviePerson.MoviePerson</returns>
        public static Model.MoviePersons.MoviePerson MapToModel(this Messaging.Views.MoviePersons.MoviePerson view) {
            return Mapper.Map<Model.MoviePersons.MoviePerson>(view);

        }

        /// <summary>
        /// Maps Model.MoviePerson.MoviePerson into List of Messaging.Views.MoviePerson.MoviePerson
        /// </summary>
        /// <param name="models"></param>
        /// <returns>List of Messaging.Views.MoviePersons.MoviePerson </returns>
        public static List<Messaging.Views.MoviePersons.MoviePerson> MapToViews(this IEnumerable<Model.MoviePersons.MoviePerson> models)
        {
            var result = new List<Messaging.Views.MoviePersons.MoviePerson>();
            if (models == null)
                return result;
            result.AddRange(models.Select(item => item.MapToView()));
            return result;
        }
    }

    }

using AutoMapper;
using AngularJsSample.Services.Messaging.Views;
using AngularJsSample.Services.Messaging.Views.MovieGenres;
using System.Collections.Generic;
using System.Linq;

namespace AngularJsSample.Services.Mapping
{
    public static class MovieGenresMapper
    {


        public static Messaging.Views.MovieGenres.MovieGenre MapToView(this Model.MovieGenres.MovieGenre model)
        {
            return Mapper.Map<Messaging.Views.MovieGenres.MovieGenre>(model);
        }
    

        public static Model.MovieGenres.MovieGenre MapToModel(this Messaging.Views.MovieGenres.MovieGenre view) {
            return Mapper.Map<Model.MovieGenres.MovieGenre>(view);

        }
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

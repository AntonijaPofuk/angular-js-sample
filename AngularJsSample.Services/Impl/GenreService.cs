using AngularJsSample.Model.Genres;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.Genres;
using System;
using System.Web;
using System.Web.ModelBinding;

namespace AngularJsSample.Services.Impl
{

    public class GenreService : IGenreService {

        private IGenreRepository _repository;

        public GenreService(IGenreRepository repository) {

            _repository = repository;

        }


        public GetGenreResponse GetGenre(GetGenreRequest request)
        {
            throw new NotImplementedException();
        }

        public GetGenresResponse GetGenres(GetGenresRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

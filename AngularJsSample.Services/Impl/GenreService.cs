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
            var response = new GetGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Genre = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public GetGenresResponse GetGenres(GetGenresRequest request)
        {
            var response = new GetGenresResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Genres = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}

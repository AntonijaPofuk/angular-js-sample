using AngularJsSample.Model.MovieGenres;
using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MovieGenres;
using System;
using System.Web;
using System.Web.ModelBinding;

namespace AngularJsSample.Services.Impl
{

    public class MovieGenreService : IMovieGenreService {

        private IMovieGenreRepository _repository;

        public MovieGenreService(IMovieGenreRepository repository) {

            _repository = repository;

        }


        public GetMovieGenreResponse GetMovieGenre(GetMovieGenreRequest request)
        {
            var response = new GetMovieGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.MovieGenre = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

       
        SaveMovieGenreResponse IMovieGenreService.SaveMovieGenre(SaveMovieGenreRequest request)
        {
            //var response = new SaveMovieGenreResponse()
            //{
            //    Request = request,
            //    ResponseToken = Guid.NewGuid()
            //};
            //try
            //{
            //    if (request.MovieGenre?.MovieId == 0)
            //    {
            //        response.MovieGenre = request.MovieGenre;
            //        response.MovieGenre.MovieId = _repository.Add(request.MovieGenre.MapToModel());
            //        response.Success = true;
            //    }
            //    else if (request.MovieGenre?.MovieId > 0)
            //    {
            //        response.MovieGenre = _repository.Save(request.MovieGenre.MapToModel()).MapToView();
            //        response.Success = true;
            //    }
            //    else
            //    {
            //        response.Success = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    response.Message = ex.Message;
            //    response.Success = false;
            //}
            //return response;
            return null;
        }
    }
}

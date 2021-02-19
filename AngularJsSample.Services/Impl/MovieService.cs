using AngularJsSample.Model.Movies;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.Movies;
using System;
using System.Web;
using System.Web.ModelBinding;

namespace AngularJsSample.Services.Impl
{

    public class MovieService : IMovieService {

        private IMovieRepository _repository;

        public MovieService(IMovieRepository repository) {

            _repository = repository;

        }


        public GetMovieResponse GetMovie(GetMovieRequest request)
        {
            var response = new GetMovieResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Movie = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public GetMoviesResponse GetMovies(GetMoviesRequest request)
        {
            var response = new GetMoviesResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Movies = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public DeleteMovieResponse DeleteMovie(DeleteMovieRequest request)
        {
            var response = new DeleteMovieResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Delete(
                    new Movie()
                    {
                        Id = request.Id,
                        LastModified = DateTimeOffset.Now,
                        UserLastModified = new Model.Users.UserInfo()
                        {
                            Id = request.UserId
                        }
                    }
                    );
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        SaveMovieResponse IMovieService.SaveMovie(SaveMovieRequest request)
        {
            var response = new SaveMovieResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };
            try
            {
                if (request.Movie?.Id == 0)
                {
                    response.Movie = request.Movie;
                    response.Movie.Id = _repository.Add(request.Movie.MapToModel());
                    response.Success = true;
                }
                else if (request.Movie?.Id > 0)
                {
                    response.Movie = _repository.Save(request.Movie.MapToModel()).MapToView();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }
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

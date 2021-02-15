using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MoviePersons;
using System;
using System.Web;
using System.Web.ModelBinding;

namespace AngularJsSample.Services.Impl
{
    public class MoviePersonService : IMoviePersonService
    {
       
        private IMoviePersonRepository _repository;
        public MoviePersonService(IMoviePersonRepository repository)
        {
            _repository = repository;

        }

        public DeleteMoviePersonResponse DeleteMoviePerson(DeleteMoviePersonRequest request)
        {
            var response = new DeleteMoviePersonResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Delete(
                    new MoviePerson()
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

        public GetMoviePersonResponse GetMoviePerson(GetMoviePersonRequest request)
        {
            var response = new GetMoviePersonResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.MoviePerson = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public GetMoviePersonsResponse GetMoviePersons(GetMoviePersonsRequest request)
        {
            var response = new GetMoviePersonsResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.MoviePersons = _repository.FindAll().MapToViews();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public SaveMoviePersonResponse SaveMoviePerson(SaveMoviePersonRequest request)
        {
            var response = new SaveMoviePersonResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };
                try
                {

                    if (request.MoviePerson?.Id == 0)
                    {
                        response.MoviePerson = request.MoviePerson;
                        response.MoviePerson.Id = _repository.Add(request.MoviePerson.MapToModel());
                        response.Success = true;
                    }
                    else if (request.MoviePerson?.Id > 0)
                    {
                        response.MoviePerson = _repository.Save(request.MoviePerson.MapToModel()).MapToView();
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

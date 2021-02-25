using AngularJsSample.Model.Genres;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.Genres;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.ModelBinding;

namespace AngularJsSample.Services.Impl
{

    public class GenreService : IGenreService
    {

        private IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {

            _repository = repository;

        }

        /// <summary>
        /// Handling get request and response
        /// </summary>
        /// <param name="request">Messaging.Genres</param>
        /// <returns>Messaging.Genres</returns>
        public GetGenreResponse GetGenre(GetGenreRequest request)
        {
            var response = new GetGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Genre = _repository.FindAll(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
        /// <summary>
        /// Handling get request and response
        /// </summary>
        /// <param name="request">Messaging.Genres.GetGenresRequest</param>
        /// <returns>Messaging.Genres.GetGenresResponse</returns>
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
        /// <summary>
        /// Handling delete request and response
        /// </summary>
        /// <param name="request">Messaging.Genres.DeleteGenreRequest</param>
        /// <returns>Messaging.Genres.DeleteGenreResponse</returns>
        public DeleteGenreResponse DeleteGenre(DeleteGenreRequest request)
        {
            var response = new DeleteGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Delete(
                    new Genre()
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

        /// <summary>
        /// Handling save request and response
        /// </summary>
        /// <param name="request">Messaging.Genres.SaveGenreRequest</param>
        /// <returns>Messaging.Genres.SaveGenreResponse</returns>
        SaveGenreResponse IGenreService.SaveGenre(SaveGenreRequest request)
        {
            var response = new SaveGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };
            try
            {
                if (request.Genre?.Id == 0)
                {
                    if (ServerValidation(request)) //server-side validation
                    {
                        response.Genre = request.Genre;
                        response.Genre.Id = _repository.Add(request.Genre.MapToModel());
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                    }
                }
                else if (request.Genre?.Id > 0)
                {
                    if (ServerValidation(request)) //server-side validation
                    {
                        response.Genre = _repository.Save(request.Genre.MapToModel()).MapToView();
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                    }
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
        /// <summary>
        /// Validation function 
        /// </summary>
        /// <param name="item">SaveGenreRequest</param>
        /// <returns>System.Boolean: true if validation is ok, else false</returns>
        bool ServerValidation(SaveGenreRequest item)
        {
            try
            {
                if (item.Genre.Name == null || !(item.Genre.Name is String) || item.Genre.Name.Length > 50) throw new ValidationException("Genre name is required or is bigger than 50!");
                // TODO fix server-validation for not required fields genre
                return true;
            }
            catch (ValidationException e)
            {
                return false;
            }
        }
    }
}
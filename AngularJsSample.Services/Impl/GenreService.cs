﻿using AngularJsSample.Model.Genres;
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
                    response.Genre = request.Genre;
                    response.Genre.Id = _repository.Add(request.Genre.MapToModel());
                    response.Success = true;
                }
                else if (request.Genre?.Id > 0)
                {
                    response.Genre = _repository.Save(request.Genre.MapToModel()).MapToView();
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

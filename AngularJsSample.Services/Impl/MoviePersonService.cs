﻿using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MoviePersons;
using System;
using System.ComponentModel.DataAnnotations;
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
                response.MoviePerson = _repository.FindAll(request.Id).MapToView();
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
                    if (ServerValidation(request)) //server-side validation
                    {

                        response.MoviePerson = request.MoviePerson;
                        response.MoviePerson.Id = _repository.Add(request.MoviePerson.MapToModel());

                        response.Success = true;
                    }
                    else {
                        response.Success = false;
                    }
                }
                else if (request.MoviePerson?.Id > 0)
                {
                    if (ServerValidation(request)) //server-side validation
                    {
                        response.MoviePerson = _repository.Save(request.MoviePerson.MapToModel()).MapToView();
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
        bool ServerValidation(SaveMoviePersonRequest item)
        {
            try
            {
                if (item.MoviePerson.FirstName == null || !(item.MoviePerson.LastName is String) || item.MoviePerson.FirstName.Length > 50) throw new ValidationException("First name is required or is bigger than 50!");
                if (item.MoviePerson.LastName == null || !(item.MoviePerson.LastName is String) || item.MoviePerson.LastName.Length > 50) throw new ValidationException("Last name name is required or is bigger than 50!");
                if (item.MoviePerson.Birthday == null) throw new ValidationException("Birthday is required!");
                if (item.MoviePerson.BirthPlace == null || !(item.MoviePerson.BirthPlace is String) || item.MoviePerson.BirthPlace.Length > 50) throw new ValidationException("Birthplace is required!");
                if (item.MoviePerson.Popularity < 1 || item.MoviePerson.Popularity > 100) throw new ValidationException("Popularity is required or is not inside required rang(1,100)");
                
                // TODO fix server-validation for not required fields
                //if (item.MoviePerson.Biography is String && item.MoviePerson.Biography.Length < 2000) throw new ValidationException("Biography is not string or bigger than 2000 characters!");
                //if (item.MoviePerson.IMDBUrl is String && item.MoviePerson.IMDBUrl.Length < 2000) throw new ValidationException("IMDBUrl is not string or bigger than 2000 characters!");
                //if (item.MoviePerson.PhotoUrl is String && item.MoviePerson.PhotoUrl.Length < 2000) throw new ValidationException("PhotoUrl is not string or bigger than 2000 characters!");
                return true;
            }
            catch (ValidationException e)
            {
                return false;
            }
        }
    }
}



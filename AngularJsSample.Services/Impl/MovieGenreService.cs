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

        /// <summary>
        /// Handling get request and response
        /// </summary>
        /// <param name="request">Messaging.MovieGenres.GetMovieGenreRequest</param>
        /// <returns>Messaging.MovieGenres.GetMovieGenreResponse</returns>
        public GetMovieGenreResponse GetMovieGenre(GetMovieGenreRequest request)
        {
            var response = new GetMovieGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.MovieGenres = _repository.FindAllBy(request.Id).MapToViews();
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
        /// <param name="request">Messaging.MovieGenres.DeleteMovieGenreRequest</param>
        /// <returns>Messaging.MovieGenres.DeleteMovieGenreResponse</returns>
        public DeleteMovieGenreResponse DeleteMovieGenre(DeleteMovieGenreRequest request)
        {
            var response = new DeleteMovieGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Delete(
                    new MovieGenre()
                    {
                        GenreId = new Model.Genres.Genre()
                        {
                            Id = request.GenreId
                        },
                        MovieId = new Model.Movies.Movie()
                        {
                            Id = request.MovieId
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
        /// <param name="request">Messaging.MovieGenres.SaveMovieGenreResponse</param>
        /// <returns>Messaging.MovieGenres.SaveMovieGenreRequest</returns>
        SaveMovieGenreResponse IMovieGenreService.SaveMovieGenre(SaveMovieGenreRequest request)
        {
            var response = new SaveMovieGenreResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };
            try
            {
                     _repository.AddMovieGenre(request.MovieId, request.GenreId);

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

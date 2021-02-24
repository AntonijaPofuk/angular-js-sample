using System.Web;
using System.Web.Http;
using System;
using AngularJsSample.Services;
using AngularJsSample.Api.Helpers;
using AngularJsSample.Api.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Api.Models;
using System.Net.Http;
using System.Web.Services.Description;
using System.Net;
using AngularJsSample.Api.Mapping.MovieGenres;
using System.Web.Http.Cors;

namespace AngularJsSample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/moviegenres")]

    public class MovieGenreController : ApiController
    {
        private readonly IMovieGenreService _movieGenreService; //injection

        public MovieGenreController(IMovieGenreService movieGenreService)
        {
            _movieGenreService = movieGenreService;
        }               

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetMovieGenreRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var moviegenresResponse = _movieGenreService.GetMovieGenre(request);

            if (!moviegenresResponse.Success)
            {
                return BadRequest(moviegenresResponse.Message);
            }

            return Ok(
                new
                {
                    moviegenres = moviegenresResponse.MovieGenres.MapToViewModels()
                }
            );

        }

        [HttpDelete]
        [Route("{movieId}/{genreId}")]

        public IHttpActionResult Delete(int movieId, int genreId)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new DeleteMovieGenreRequest()
            {
                RequestToken = Guid.NewGuid(),
                MovieId=movieId,
                GenreId = genreId
            };

            var movieGenresResponse = _movieGenreService.DeleteMovieGenre(request);

            if (!movieGenresResponse.Success)
            {
                return BadRequest(movieGenresResponse.Message);
            }

            return Ok();
        }

    }
}


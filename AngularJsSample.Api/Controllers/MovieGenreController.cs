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

        /// <summary>
        /// GET request for MovieGenres
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
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

        /// <summary>
        /// DELETE request for MovieGenre
        /// </summary>
        /// <param name="movieId">Movie id</param>
        /// <param name="genreId">Genre id</param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
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

        /// <summary>
        /// POST request for MovieGenre
        /// </summary>
        /// <param name="movieGenre">MovieGenreViewModel</param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(MovieGenreViewModel movieGenre)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();           

            var request = new SaveMovieGenreRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                MovieId = movieGenre.MovieId.Id,
                GenreId = movieGenre.GenreId.Id
            };

            var movieGenresResponse = _movieGenreService.SaveMovieGenre(request);

            if (!movieGenresResponse.Success)
            {
                return BadRequest(movieGenresResponse.Message);
            }

            return Ok(movieGenre = movieGenresResponse.MovieGenre.MapToViewModel());
        }
    }
}


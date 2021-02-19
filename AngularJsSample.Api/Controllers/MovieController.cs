using System.Web;
using System.Web.Http;
using System;
using AngularJsSample.Services;
using AngularJsSample.Api.Helpers;
using AngularJsSample.Api.Mapping;
using AngularJsSample.Services.Messaging.Movies;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Api.Models;
using System.Net.Http;
using System.Web.Services.Description;
using System.Net;
using AngularJsSample.Api.Mapping.Movies;

namespace AngularJsSample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private readonly IMovieService _movieService; //injection

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetMoviesRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var moviesResponse = _movieService.GetMovies(request);

            if (!moviesResponse.Success)
            {
                return BadRequest(moviesResponse.Message);
            }

            return Ok(
                new
                {
                    movies = moviesResponse.Movies.MapToViewModels()
                }
            );
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetMovieRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var movieResponse = _movieService.GetMovie(request);

            if (!movieResponse.Success)
            {
                return BadRequest(movieResponse.Message);
            }

            return Ok( movieResponse.Movie.MapToViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new DeleteMovieRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var moviesResponse = _movieService.DeleteMovie(request);

            if (!moviesResponse.Success)
            {
                return BadRequest(moviesResponse.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, MovieViewModel movie)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            movie.UserLastModified = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            movie.Lastmodified = DateTimeOffset.Now;


            if (ModelState.IsValid)
            {
                var request = new SaveMovieRequest()
                {
                    RequestToken = Guid.NewGuid(),
                    UserId = loggedUserId,
                    Movie = movie.MapToView()
                };

                var moviesResponse = _movieService.SaveMovie(request);

                if (!moviesResponse.Success)
                {
                    return BadRequest(moviesResponse.Message);
                }

                return Ok(movie = moviesResponse.Movie.MapToViewModel());
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(MovieViewModel movie)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            movie.UserCreated = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            movie.Datecreated = DateTimeOffset.Now;

            var request = new SaveMovieRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Movie = movie.MapToView()
            };

            var moviesResponse = _movieService.SaveMovie(request);

            if (!moviesResponse.Success)
            {
                return BadRequest(moviesResponse.Message);
            }

            return Ok(movie = moviesResponse.Movie.MapToViewModel());
        }
    }
}


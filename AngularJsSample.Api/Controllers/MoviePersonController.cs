using System.Web;
using System.Web.Http;
using System;
using AngularJsSample.Services;
using AngularJsSample.Api.Helpers;
using AngularJsSample.Api.Mapping.MoviePersons;
using AngularJsSample.Services.Messaging.MoviePersons;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Api.Models;
using System.Net.Http;
using System.Web.Services.Description;
using System.Net;

namespace AngularJsSample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/moviepersons")]
    public class MoviePersonController : ApiController
    {
        private readonly IMoviePersonService _moviePersonService; //injection

        public MoviePersonController(IMoviePersonService moviePersonService)
        {
            _moviePersonService = moviePersonService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetMoviePersonsRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var moviePersonsResponse = _moviePersonService.GetMoviePersons(request);

            if (!moviePersonsResponse.Success)
            {
                return BadRequest(moviePersonsResponse.Message);
            }

            return Ok(
                new
                {
                    moviePersons = moviePersonsResponse.MoviePersons.MapToViewModels()
                }
            );
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetMoviePersonRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var moviePersonResponse = _moviePersonService.GetMoviePerson(request);

            if (!moviePersonResponse.Success)
            {
                return BadRequest(moviePersonResponse.Message);
            }

            return Ok( moviePersonResponse.MoviePerson.MapToViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new DeleteMoviePersonRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var moviePersonsResponse = _moviePersonService.DeleteMoviePerson(request);

            if (!moviePersonsResponse.Success)
            {
                return BadRequest(moviePersonsResponse.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(MoviePersonViewModel moviePerson)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            moviePerson.UserCreated = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            moviePerson.Datecreated = DateTimeOffset.Now;

            var request = new SaveMoviePersonRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                MoviePerson = moviePerson.MapToView()
            };

            var moviePersonsResponse = _moviePersonService.SaveMoviePerson(request);

            if (!moviePersonsResponse.Success)
            {
                return BadRequest(moviePersonsResponse.Message);
            }

            return Ok(moviePerson = moviePersonsResponse.MoviePerson.MapToViewModel());
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, MoviePersonViewModel moviePerson)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            moviePerson.UserLastModified = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            moviePerson.Lastmodified = DateTimeOffset.Now;


            if (ModelState.IsValid)
            {
                var request = new SaveMoviePersonRequest()
                {
                    RequestToken = Guid.NewGuid(),
                    UserId = loggedUserId,
                    MoviePerson = moviePerson.MapToView()
                };

                var moviePersonsResponse = _moviePersonService.SaveMoviePerson(request);

                if (!moviePersonsResponse.Success)
                {
                    return BadRequest(moviePersonsResponse.Message);
                }

                return Ok(moviePerson = moviePersonsResponse.MoviePerson.MapToViewModel());
            }
            else {
                return BadRequest();
            }

        }

    }
}


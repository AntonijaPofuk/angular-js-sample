using System.Web;
using System.Web.Http;
using System;
using AngularJsSample.Services;
using AngularJsSample.Api.Helpers;
using AngularJsSample.Api.Mapping;
using AngularJsSample.Services.Messaging.MovieGenres;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Api.Models;
using System.Net.Http;
using System.Web.Services.Description;
using System.Net;
using AngularJsSample.Api.Mapping.Movies;

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
        [Route("")]
        public IHttpActionResult Get()
        {
            //var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            //var request = new GetMovieGenresRequest()
            //{
            //    RequestToken = Guid.NewGuid(),
            //    UserId = loggedUserId
            //};

            //var movieGenresResponse = _movieGenreService.GetMovieGenres(request);

            //if (!movieGenresResponse.Success)
            //{
            //    return BadRequest(movieGenresResponse.Message);
            //}

            //return Ok(
            //    new
            //    {
            //        movieGenres = movieGenresResponse.MovieGenres.MapToViewModels()
            //    }
            //);
            return null;

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

            var movieGenreResponse = _movieGenreService.GetMovieGenre(request);

            if (!movieGenreResponse.Success)
            {
                return BadRequest(movieGenreResponse.Message);
            }

            // return Ok( movieGenreResponse.MovieGenre.MapToViewModel());
            return null;

        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            //var request = new DeleteMovieGenreRequest()
            //{
            //    RequestToken = Guid.NewGuid(),
            //    UserId = loggedUserId,
            //    Id = id
            //};

            //var movieGenresResponse = _movieGenreService.DeleteMovieGenre(request);

            //if (!movieGenresResponse.Success)
            //{
            //    return BadRequest(movieGenresResponse.Message);
            //}

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, MovieGenreViewModel movieGenre)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            //movieGenre.UserLastModified = new Models.Users.UserViewModel()
            //{
            //    Id = loggedUserId
            //};
            //movieGenre.Lastmodified = DateTimeOffset.Now;


            //if (ModelState.IsValid)
            //{
            //    var request = new SaveMovieGenreRequest()
            //    {
            //        RequestToken = Guid.NewGuid(),
            //        UserId = loggedUserId,
            //        MovieGenre = movieGenre.MapToView()
            //    };

            //    var movieGenresResponse = _movieGenreService.SaveMovieGenre(request);

            //    if (!movieGenresResponse.Success)
            //    {
            //        return BadRequest(movieGenresResponse.Message);
            //    }

            //    return Ok(movieGenre = movieGenresResponse.MovieGenre.MapToViewModel());
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return null;

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(MovieGenreViewModel movieGenre)
        {
            //var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            //movieGenre.UserCreated = new Models.Users.UserViewModel()
            //{
            //    Id = loggedUserId
            //};
            //movieGenre.Datecreated = DateTimeOffset.Now;

            //var request = new SaveMovieGenreRequest()
            //{
            //    RequestToken = Guid.NewGuid(),
            //    UserId = loggedUserId,
            //    MovieGenre = movieGenre.MapToView()
            //};

            //var movieGenresResponse = _movieGenreService.SaveMovieGenre(request);

            //if (!movieGenresResponse.Success)
            //{
            //    return BadRequest(movieGenresResponse.Message);
            //}

            //return Ok(movieGenre = movieGenresResponse.MovieGenre.MapToViewModel());
            return null;

        }
    }
}


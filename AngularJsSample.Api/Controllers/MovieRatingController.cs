using System.Web;
using System.Web.Http;
using System;
using AngularJsSample.Services;
using AngularJsSample.Api.Helpers;
using AngularJsSample.Api.Mapping;
using AngularJsSample.Services.Messaging.MovieRatings;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Api.Models;
using System.Net.Http;
using System.Web.Services.Description;
using System.Net;
using AngularJsSample.Api.Mapping.MovieRatings;

namespace AngularJsSample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/movieratings")]
    public class MovieRatingController : ApiController
    {
        private readonly IMovieRatingService _movieratingService; //injection

        public MovieRatingController(IMovieRatingService movieratingService)
        {
            _movieratingService = movieratingService;
        }

       [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetMovieRatingRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var movieratingResponse = _movieratingService.GetMovieRating(request);

            if (!movieratingResponse.Success)
            {
                return BadRequest(movieratingResponse.Message);
            }

            return Ok( movieratingResponse.MovieRating.MapToViewModel());
        }

       
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, MovieRatingViewModel movierating)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

          

            if (ModelState.IsValid)
            {
                var request = new SaveMovieRatingRequest()
                {
                    RequestToken = Guid.NewGuid(),
                    UserId = loggedUserId,
                    MovieRating = movierating.MapToView()
                };

                var movieratingsResponse = _movieratingService.SaveMovieRating(request);

                if (!movieratingsResponse.Success)
                {
                    return BadRequest(movieratingsResponse.Message);
                }

                return Ok(movierating = movieratingsResponse.MovieRating.MapToViewModel());
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(MovieRatingViewModel movierating)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            movierating.UserCreated = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            movierating.Datecreated = DateTimeOffset.Now;

            var request = new SaveMovieRatingRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                MovieRating = movierating.MapToView()
            };

            var movieratingsResponse = _movieratingService.SaveMovieRating(request);

            if (!movieratingsResponse.Success)
            {
                return BadRequest(movieratingsResponse.Message);
            }

            return Ok(movierating = movieratingsResponse.MovieRating.MapToViewModel());
        }
    }
}


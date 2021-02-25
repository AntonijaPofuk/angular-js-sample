using System.Web;
using System.Web.Http;
using System;
using AngularJsSample.Services;
using AngularJsSample.Api.Helpers;
using AngularJsSample.Api.Mapping;
using AngularJsSample.Services.Messaging.Genres;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Api.Models;
using System.Net.Http;
using System.Web.Services.Description;
using System.Net;
using AngularJsSample.Api.Mapping.Genres;

namespace AngularJsSample.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/genres")]
    public class GenreController : ApiController
    {
        private readonly IGenreService _genreService; //injection

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        /// <summary>
        /// GET request for Genres
        /// </summary>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetGenresRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var genresResponse = _genreService.GetGenres(request);

            if (!genresResponse.Success)
            {
                return BadRequest(genresResponse.Message);
            }

            return Ok(
                new
                {
                    genres = genresResponse.Genres.MapToViewModels()
                }
            );
        }

        /// <summary>
        /// DELETE request for Genres
        /// </summary>
        /// <param name="id">Genre id</param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetGenreRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var genreResponse = _genreService.GetGenre(request);

            if (!genreResponse.Success)
            {
                return BadRequest(genreResponse.Message);
            }

            return Ok( genreResponse.Genre.MapToViewModel());
        }

        /// <summary>
        ///  DELETE request for MoviePerson
        /// </summary>
        /// <param name="id">Genre id</param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new DeleteGenreRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Id = id
            };

            var genresResponse = _genreService.DeleteGenre(request);

            if (!genresResponse.Success)
            {
                return BadRequest(genresResponse.Message);
            }

            return Ok();
        }

        /// <summary>
        /// PUT request for Genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genre">GenreViewModel</param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, GenreViewModel genre)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            genre.UserLastModified = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            genre.Lastmodified = DateTimeOffset.Now;


            if (ModelState.IsValid)
            {
                var request = new SaveGenreRequest()
                {
                    RequestToken = Guid.NewGuid(),
                    UserId = loggedUserId,
                    Genre = genre.MapToView()
                };

                var genresResponse = _genreService.SaveGenre(request);

                if (!genresResponse.Success)
                {
                    return BadRequest(genresResponse.Message);
                }

                return Ok(genre = genresResponse.Genre.MapToViewModel());
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// POST request for Genre
        /// </summary>
        /// <param name="genre">GenreViewModel</param>
        /// <returns>IHttpActionResult: OK or BadRequest</returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(GenreViewModel genre)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            genre.UserCreated = new Models.Users.UserViewModel()
            {
                Id = loggedUserId
            };
            genre.Datecreated = DateTimeOffset.Now;

            var request = new SaveGenreRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Genre = genre.MapToView()
            };

            var genresResponse = _genreService.SaveGenre(request);

            if (!genresResponse.Success)
            {
                return BadRequest(genresResponse.Message);
            }

            return Ok(genre = genresResponse.Genre.MapToViewModel());
        }
    }
}


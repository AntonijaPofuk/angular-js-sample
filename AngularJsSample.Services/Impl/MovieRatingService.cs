using AngularJsSample.Model.MovieRatings;
using AngularJsSample.Services.Mapping;
using AngularJsSample.Services.Messaging;
using AngularJsSample.Services.Messaging.MovieRatings;
using System;
using System.Web;
using System.Web.ModelBinding;

namespace AngularJsSample.Services.Impl
{

    public class MovieRatingService : IMovieRatingService {

        private IMovieRatingRepository _repository;

        public MovieRatingService(IMovieRatingRepository repository) {

            _repository = repository;

        }


        public GetMovieRatingResponse GetMovieRating(GetMovieRatingRequest request)
        {
            var response = new GetMovieRatingResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.MovieRating = _repository.FindBy(request.Id).MapToView();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

       
        SaveMovieRatingResponse IMovieRatingService.SaveMovieRating(SaveMovieRatingRequest request)
        {
            var response = new SaveMovieRatingResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };
            try
            {
                if (request.MovieRating?.MovieId == 0)
                {
                    response.MovieRating = request.MovieRating;
                    response.MovieRating.MovieId = _repository.Add(request.MovieRating.MapToModel());
                    response.Success = true;
                }
                else if (request.MovieRating?.MovieId > 0)
                {
                    response.MovieRating = _repository.Save(request.MovieRating.MapToModel()).MapToView();
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

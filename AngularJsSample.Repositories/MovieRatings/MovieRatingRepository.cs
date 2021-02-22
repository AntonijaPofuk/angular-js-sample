using System;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Model;
using AngularJsSample.Model.MovieRatings;
using AngularJsSample.Model.Users;
using AngularJsSample.Repositories.DatabaseModel;
using Context = AngularJsSample.Repositories.DatabaseModel;

namespace AngularJsSample.Repositories
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        public int Add(Model.MovieRatings.MovieRating item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.MovieRatings.MovieRating item)
        {
            throw new NotImplementedException();
        }

        public List<Model.MovieRatings.MovieRating> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.MovieRatings.MovieRating FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Model.MovieRatings.MovieRating Save(Model.MovieRatings.MovieRating item)
        {
            throw new NotImplementedException();
        }
    }
}


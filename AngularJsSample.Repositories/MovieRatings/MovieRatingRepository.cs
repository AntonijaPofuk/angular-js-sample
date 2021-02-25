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
        /// <summary>
        /// Adds object with items to POST request
        /// </summary>
        /// <param name="item">Model.MovieRatings.MovieRating object</param>
        /// <returns>context.Rating_Insert</returns>
        public int Add(Model.MovieRatings.MovieRating item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
               
                    return context.Rating_Insert(item.MovieId, item.UserRatedId, item.UserCreated?.Id, item.Rating);
                
            }
        }

        public bool Delete(Model.MovieRatings.MovieRating item)
        {
            throw new NotImplementedException();
        }

        public List<Model.MovieRatings.MovieRating> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.MovieRatings.MovieRating FindAll(int key)
        {
            throw new NotImplementedException();

        }

        public List<Model.MovieRatings.MovieRating> FindAllBy(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds object to UPDATE request 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Model.MovieRatings.MovieRating</returns>
        public Model.MovieRatings.MovieRating Save(Model.MovieRatings.MovieRating item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                context.Rating_Save(item.MovieId, item.UserRatedId, item.Rating);
                return item;
            }
        }
    }
}


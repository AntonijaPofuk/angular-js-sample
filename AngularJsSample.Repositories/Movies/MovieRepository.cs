using System;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Model;
using AngularJsSample.Model.Movies;
using AngularJsSample.Model.Users;
using AngularJsSample.Repositories.DatabaseModel;
using Context = AngularJsSample.Repositories.DatabaseModel;

namespace AngularJsSample.Repositories
{
    /*
    Repository class
    Contains implementation of methods from IMovieRepository
    */
    public class MovieRepository : IMovieRepository
    {

        /// <summary>
        /// Adds items for insertion into db
        /// </summary>
        /// <returns>
        /// context.Movie_Insert
        /// </returns>
        /// <param name="item">Model.Movies.Movie</param>
        public int Add(Model.Movies.Movie item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.Movie_Insert(item.Name, item.ReleaseDate, item.Description, item.UserCreated.Id, item.PosterUrl, item.IMDBUrl, item.Rating);
            }
        }

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <returns>
        /// System.Boolean
        /// </returns>
        /// <param name="item">Model.Movies.Movie</param>
        public bool Delete(Model.Movies.Movie item)
        {
            try
            {
                using (var context = new AngularJsSampleDbEntities())
                {
                    context.Movie_Delete(item.Id, item.UserLastModified?.Id);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The exception is: '{e}'");
                return false;
            }
        }

        /// <summary>
        /// Finds items 
        /// </summary>
        /// <returns>
        /// List<Model.Movies.Movie>
        /// </returns>
        public List<Model.Movies.Movie> FindAll()
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                List<Model.Movies.Movie> list = new List<Model.Movies.Movie>();
                foreach (var item in context.Movies_Get().ToList())
                {
                    list.Add(item.MapToModels());
                }
                return list;
            }
        }
        /// <summary>
        /// Finds movies by param key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Context.MovieData_Get</returns>
        public Model.Movies.Movie FindAll(int key)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.MovieData_Get(key).FirstOrDefault().MapToModel();
            }
        }

        public List<Model.Movies.Movie> FindAllBy(int key)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Adds items for updating existing item 
        /// </summary>
        /// <returns>
        /// context.Movie_Save
        /// </returns>
        /// <param name="item">Model.Movies.Movie</param>
        public Model.Movies.Movie Save(Model.Movies.Movie item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                context.Movie_Save(item.Id, item.Name, item.ReleaseDate, item.Description, item.PosterUrl,
                    item.IMDBUrl, item.Rating, item.UserLastModified?.Id);                
                return item;
            }
        }
    }
}


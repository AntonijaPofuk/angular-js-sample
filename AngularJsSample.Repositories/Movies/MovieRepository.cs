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
    public class MovieRepository : IMovieRepository
    {
        public int Add(Model.Movies.Movie item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.Movie_Insert(item.Name, item.ReleaseDate, item.Description, item.UserCreated.Id, item.PosterUrl, item.IMDBUrl, item.Rating);
            }
        }

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

        public Model.Movies.Movie FindBy(int key)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.MovieData_Get(key).FirstOrDefault().MapToModel();
            }
        }

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


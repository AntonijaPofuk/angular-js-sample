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
            throw new NotImplementedException();
        }

        public bool Delete(Model.Movies.Movie item)
        {
            throw new NotImplementedException();
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
                return context.MovieData_Get(key).SingleOrDefault().MapToModel();
            }
        }

        public Model.Movies.Movie Save(Model.Movies.Movie item)
        {
            throw new NotImplementedException();
        }
    }
}


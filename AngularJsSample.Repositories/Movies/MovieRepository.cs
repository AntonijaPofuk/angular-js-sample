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
            throw new NotImplementedException();
        }

        public Model.Movies.Movie FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Model.Movies.Movie Save(Model.Movies.Movie item)
        {
            throw new NotImplementedException();
        }
    }
}


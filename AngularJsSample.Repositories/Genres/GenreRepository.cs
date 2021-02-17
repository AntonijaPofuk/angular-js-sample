using System;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Model;
using AngularJsSample.Model.Genres;
using AngularJsSample.Model.Users;
using AngularJsSample.Repositories.DatabaseModel;
using Context = AngularJsSample.Repositories.DatabaseModel;

namespace AngularJsSample.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public int Add(Model.Genres.Genre item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.Genres.Genre item)
        {
            throw new NotImplementedException();
        }

        public List<Model.Genres.Genre> FindAll()
        {
            throw new NotImplementedException();
        }

        public Model.Genres.Genre FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public Model.Genres.Genre Save(Model.Genres.Genre item)
        {
            throw new NotImplementedException();
        }
    }
}

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
            try
            {
                using (var context = new AngularJsSampleDbEntities())
                {
                    context.Genre_Delete(item.Id, item.UserLastModified?.Id);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The exception is: '{e}'");
                return false;
            }
        }

        public List<Model.Genres.Genre> FindAll()
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                List<Model.Genres.Genre> list = new List<Model.Genres.Genre>();
                foreach (var item in context.Genres_Get().ToList())
                {
                    list.Add(item.MapToModels());
                }
                return list;
            }
        }

        public Model.Genres.Genre FindBy(int key)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.GenreData_Get(key).SingleOrDefault().MapToModel();
            }
        }

        public Model.Genres.Genre Save(Model.Genres.Genre item)
        {
            throw new NotImplementedException();
        }
    }
}

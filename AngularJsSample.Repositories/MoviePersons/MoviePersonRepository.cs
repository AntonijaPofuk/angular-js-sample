using System;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Model;
using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Model.Users;
using AngularJsSample.Repositories.DatabaseModel;
using Context = AngularJsSample.Repositories.DatabaseModel;

namespace AngularJsSample.Repositories
{
    public class MoviePersonRepository : IMoviePersonRepository
    {

        public int Add(Model.MoviePersons.MoviePerson item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.MoviePerson_Insert(item.FirstName, item.LastName, item.Birthday, item.BirthPlace, item.Biography, 
                    item.UserCreated?.Id, item.PhotoUrl, item.IMDBUrl, item.Popularity);
            }
        }

        public bool Delete(Model.MoviePersons.MoviePerson item)
        {
            try
            {
                using (var context = new AngularJsSampleDbEntities())
                {
                    context.MoviePerson_Delete(item.Id, item.UserLastModified?.Id);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The exception is: '{e}'");
                return false;
            }
        }

        public List<Model.MoviePersons.MoviePerson> FindAll()
        {
            using (var context = new AngularJsSampleDbEntities()) {
                List<Model.MoviePersons.MoviePerson> list = new List<Model.MoviePersons.MoviePerson>();
                foreach (var item in context.MoviePerson_Get().ToList())
                {
                    list.Add(item.MapToModels());
                }
                return list;
            }
        }

        public Model.MoviePersons.MoviePerson FindBy(int key)
        {
            using (var context = new AngularJsSampleDbEntities()) {
                return context.MoviePersonData_Get(key).SingleOrDefault().MapToModel();
            }
        }

        public Model.MoviePersons.MoviePerson Save(Model.MoviePersons.MoviePerson item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                context.MoviePerson_Save(item.Id, item.FirstName, item.LastName, 
                    item.BirthPlace, item.Birthday, item.Biography,
                    item.PhotoUrl, item.IMDBUrl, item.Popularity,
                     item.UserLastModified?.Id);
                return item;
            }
        }
    }
}

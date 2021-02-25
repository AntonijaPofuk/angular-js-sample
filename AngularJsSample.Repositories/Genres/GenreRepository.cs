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
        /// <summary>
        /// Adds object into db
        /// </summary>
        /// <param name="item">Model.Genres.Genre</param>
        /// <returns>context.Genre_Insert</returns>
        public int Add(Model.Genres.Genre item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.Genre_Insert(item.Name, item.Description, item.UserCreated?.Id);

            }
        }

        /// <summary>
        /// Deletes genre from db 
        /// </summary>
        /// <param name="item">Genre id</param>
        /// <returns>System.Boolean</returns>
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

        /// <summary>
        /// Returns list of all genres
        /// </summary>
        /// <returns>List<Model.Genres.Genre></returns>
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

        /// <summary>
        /// Returns list of all genres by id
        /// </summary>
        /// <param name="key">id</param>
        /// <returns>context.GenreData_Get</returns>
        public Model.Genres.Genre FindAll(int key)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.GenreData_Get(key).SingleOrDefault().MapToModel();
            }
        }

        public List<Model.Genres.Genre> FindAllBy(int key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Saves genre into db
        /// </summary>
        /// <param name="item">Model.Genres.Genre</param>
        /// <returns>Model.Genres.Genre</returns>
        public Model.Genres.Genre Save(Model.Genres.Genre item)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                context.Genre_Save(item.Id, item.Name, item.Description,                  
                     item.UserLastModified?.Id);
                return item;
            }
        }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Model;
using AngularJsSample.Model.MovieGenres;
using AngularJsSample.Model.MoviePersons;
using AngularJsSample.Model.Users;
using AngularJsSample.Repositories.DatabaseModel;
using Context = AngularJsSample.Repositories.DatabaseModel;

namespace AngularJsSample.Repositories
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        public int Add(MovieGenre item)
        {
            throw new NotImplementedException();
        }

        public int AddMovieGenre(int genreId, int movieId)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                return context.MovieIdGenreId_Insert(movieId, genreId);

            }
        }

        public bool Delete(MovieGenre item)
        {
            try
            {
                using (var context = new AngularJsSampleDbEntities())
                {
                    context.MovieIdGenreId_Delete(item.MovieId.Id, item.GenreId.Id);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The exception is: '{e}'");
                return false;
            }
        }

        public List<MovieGenre> FindAll()
        {
            throw new NotImplementedException();
        }

        public MovieGenre FindAll(int key)
        {
            throw new NotImplementedException();
        }

        public List<MovieGenre> FindAllBy(int key)
        {
            using (var context = new AngularJsSampleDbEntities())
            {
                List<Model.MovieGenres.MovieGenre> list = new List<Model.MovieGenres.MovieGenre>();
                foreach (var item in context.GenresFromMovie_Get(key).ToList())
                {
                    list.Add(item.MapToModels());
                }
                return list;
            }
        }

        public MovieGenre Save(MovieGenre item)
        {
            throw new NotImplementedException();
        }
    }
}

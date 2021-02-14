using AngularJsSample.Model.MoviePersons;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;



namespace AngularJsSample.Repositories
{
    public static class MoviePersonMapper
    {
        public static Model.MoviePersons.MoviePerson MapToMoviePerson(this DatabaseModel.MoviePerson model)
        {
            if (model == null)
                return null;
            return new Model.MoviePersons.MoviePerson()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthPlace = model.BirthPlace,
                Biography = model.Biography,
                Birthday = model.Birthday,
                PhotoUrl = model.PhotoUrl,
                Popularity = model.Popularity,
                IMDBUrl = model.IMDBUrl,
                DateCreated = model.DateCreated
               
            };
        }

        public static Model.MoviePersons.MoviePerson MapToModel(this MoviePersonData_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.MoviePersons.MoviePerson()
            {
                Id = dbResult.Id,
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                BirthPlace = dbResult.BirthPlace,
                Biography = dbResult.Biography,
                PhotoUrl = dbResult.PhotoUrl,
                Popularity = dbResult.Popularity,
                Birthday = dbResult.Birthday,
                IMDBUrl = dbResult.IMDBUrl,
                DateCreated = dbResult.DateCreated
              

            };
            }


        public static Model.MoviePersons.MoviePerson MapToModels(this MoviePerson_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.MoviePersons.MoviePerson()
            {
                Id = dbResult.Id,
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                BirthPlace = dbResult.BirthPlace,
                Biography = dbResult.Biography,
                PhotoUrl = dbResult.PhotoUrl,
                Popularity = dbResult.Popularity,
                Birthday = dbResult.Birthday,
                IMDBUrl = dbResult.IMDBUrl,
                DateCreated = dbResult.DateCreated
              
            };
        }
    }
}

using AngularJsSample.Model.MoviePersons;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;
using System;

namespace AngularJsSample.Repositories
{
    public static class MoviePersonMapper
    {
        /// <summary>
        /// Maps Model from DatabaseModel
        /// </summary>
        /// <param name="model">DatabaseModel.MoviePerson</param>
        /// <returns>Model.MoviePersons.MoviePerson</returns>
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
                Birthday = model.Birthday.DateTime,
                PhotoUrl = model.PhotoUrl,
                Popularity = model.Popularity,
                IMDBUrl = model.IMDBUrl,
                DateCreated = model.DateCreated.DateTime              

            };
        }

        /// <summary>
        /// Maps Model from stored procedure for one Movie Person
        /// </summary>
        /// <param name="dbResult">MoviePersonData_Get_Result</param>
        /// <returns>Model.MoviePersons.MoviePerson</returns>
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
                Birthday = dbResult.Birthday.DateTime,
                IMDBUrl = dbResult.IMDBUrl,
                DateCreated = dbResult.DateCreated.DateTime
            };
    }


        /// <summary>
        /// Maps Model from stored procedure for all MoviePersons
        /// </summary>
        /// <param name="dbResult">MoviePerson_Get_Result</param>
        /// <returns>Model.MoviePersons.MoviePerson </returns>
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
                Birthday = dbResult.Birthday.DateTime,
                IMDBUrl = dbResult.IMDBUrl,
                DateCreated = dbResult.DateCreated.DateTime             

            };
        }
    }
}

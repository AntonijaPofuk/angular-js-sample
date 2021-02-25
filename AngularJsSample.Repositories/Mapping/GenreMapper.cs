using AngularJsSample.Model.MoviePersons;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;
using System;

namespace AngularJsSample.Repositories
{
    public static class GenreMapper
    {
        /// <summary>
        /// Maps Model from DatabaseModel
        /// </summary>
        /// <param name="model">DatabaseModel.Genre</param>
        /// <returns>Model.MoviePersons.Genre</returns>
        public static Model.Genres.Genre MapToGenre(this DatabaseModel.Genre model)
        {
            if (model == null)
                return null;
            return new Model.Genres.Genre()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated.DateTime         
            };
        }

        /// <summary>
        /// Maps Model from stored procedure for one Genre
        /// </summary>
        /// <param name="dbResult">GenreData_Get_Result</param>
        /// <returns>Model.Genres.Genre</returns>
        public static Model.Genres.Genre MapToModel(this GenreData_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Genres.Genre()
            {
                Id = dbResult.Id,
                Name = dbResult.Name,
                Description = dbResult.Description,             
                DateCreated = dbResult.DateCreated.DateTime
        };
    }

        /// <summary>
        /// Maps Model from stored procedure for all MoviePersons
        /// </summary>
        /// <param name="dbResult">Genres_Get_Result</param>
        /// <returns>Model.Genres.Genre </returns>
        public static Model.Genres.Genre MapToModels(this Genres_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Genres.Genre()
            {
                Id = dbResult.Id,
                Name = dbResult.Name,
                Description = dbResult.Description,              
                DateCreated = dbResult.DateCreated.DateTime,
                UserCreated = dbResult.UserCreated.HasValue ? new Model.Users.UserInfo()
                 {
                     Id = dbResult.UserCreated.Value,
                     FullName = dbResult.UserCreatedFullName
                 } : null,
            };
        }
    }
}

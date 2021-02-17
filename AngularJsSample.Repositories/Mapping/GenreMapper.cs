using AngularJsSample.Model.MoviePersons;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;
using System;

namespace AngularJsSample.Repositories
{
    public static class GenreMapper
    {
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


        public static Model.Genres.Genre MapToModels(this Genres_Get_Result dbResult)
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
    }
}

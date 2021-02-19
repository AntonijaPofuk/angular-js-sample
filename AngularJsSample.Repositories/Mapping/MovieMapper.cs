using AngularJsSample.Model;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;
using System;

namespace AngularJsSample.Repositories
{
    public static class MovieMapper
    {
        public static Model.Movies.Movie MapToMovie(this DatabaseModel.Movie model)
        {
            if (model == null)
                return null;
            return new Model.Movies.Movie()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated.DateTime,
                ReleaseDate = model.ReleaseDate.DateTime,
                PosterUrl = model.PosterUrl,
                IMDBUrl = model.IMDBUrl  
            };
        }

        public static Model.Movies.Movie MapToModel(this MovieData_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Movies.Movie()
            {
                Id = dbResult.Id,
                Name = dbResult.Name,
                Description = dbResult.Description,             
                DateCreated = dbResult.DateCreated.DateTime,
                ReleaseDate = dbResult.ReleaseDate.DateTime,
                PosterUrl = dbResult.PosterUrl,
                IMDBUrl = dbResult.IMDBUrl
            };
    }


        public static Model.Movies.Movie MapToModels(this Movies_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.Movies.Movie()
            {
                Id = dbResult.Id,
                Name = dbResult.Name,
                Description = dbResult.Description,              
                DateCreated = dbResult.DateCreated.DateTime,
                ReleaseDate = dbResult.ReleaseDate.DateTime,
                PosterUrl = dbResult.PosterUrl,
                IMDBUrl = dbResult.IMDBUrl
            };
        }
    }
}

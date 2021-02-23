using AngularJsSample.Model;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;
using System;

namespace AngularJsSample.Repositories
{
    public static class MovieGenreMapper
    {
        //public static Model.MovieGenres.MovieGenre MapToMovieGenre(this DatabaseModel.MovieIdGenreId model)
        //{
        //    if (model == null)
        //        return null;
        //    return new Model.MovieGenres.MovieGenre()
        //    {
        //        GenreId = model.GenreId,
        //        MovieId = model.MovieId
               
        //    };
        //}


        public static Model.MovieGenres.MovieGenre MapToModels(this GenresFromMovie_Get_Result dbResult)
        {
            if (dbResult == null)
                return null;
            return new Model.MovieGenres.MovieGenre()
            {
                GenreId = dbResult.GenreId.HasValue ? new Model.Genres.Genre()
                {
                    Id = dbResult.GenreId.Value,
                    Name = dbResult.GenreName
                } : null,
                MovieId = dbResult.MovieId.HasValue ? new Model.Movies.Movie()
                 {
                     Id = dbResult.MovieId.Value
                 } : null

              

            };
        }
    }
}

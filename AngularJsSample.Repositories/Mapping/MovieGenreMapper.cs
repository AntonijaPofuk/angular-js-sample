using AngularJsSample.Model;
using System.Collections.Generic;
using System.Linq;
using AngularJsSample.Repositories.DatabaseModel;
using System;

namespace AngularJsSample.Repositories
{
    public static class MovieGenreMapper
    {

        /// <summary>
        /// Maps Model from stored procedure for all MovieGenres
        /// </summary>
        /// <param name="dbResult">GenresFromMovie_Get_Result</param>
        /// <returns>Model.MovieGenres.MovieGenre</returns>
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

using AngularJsSample.Api.Models.Users;
using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJsSample.Api.Models
{
    public class MovieGenreViewModel
    {
        public MovieViewModel MovieId { get; set; }
        public GenreViewModel GenreId { get; set; }
      
    }
}
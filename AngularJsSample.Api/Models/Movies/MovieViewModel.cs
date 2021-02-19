using AngularJsSample.Api.Models.Users;
using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJsSample.Api.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public string IMDBUrl { get; set; }
        public DateTimeOffset? Datecreated { get; set; }
        public DateTimeOffset? Lastmodified { get; set; }
        public UserViewModel UserLastModified { get; set; }
        public UserViewModel UserCreated { get; set; }
    }
}
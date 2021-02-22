using AngularJsSample.Api.Models.Users;
using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJsSample.Api.Models
{
    public class MovieRatingViewModel
    {
        public int MovieId { get; set; }
        public int UserRatedId { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset? Datecreated { get; set; }
        public UserViewModel UserCreated { get; set; }
    }
}
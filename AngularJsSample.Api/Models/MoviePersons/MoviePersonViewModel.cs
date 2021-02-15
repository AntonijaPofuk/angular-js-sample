using AngularJsSample.Api.Models.Users;
using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsSample.Api.Models
{
    public class MoviePersonViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FullName { get; set; }
        public string Birthplace { get; set; }
        public string Biography { get; set; }
        public string Photourl { get; set; }
        public int Popularity { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string IMDBUrl { get; set; }
        public DateTimeOffset Datecreated { get; set; }
        public DateTimeOffset Lastmodified { get; set; }
        public UserViewModel UserLastModified { get; set; }
        public UserViewModel UserCreated { get; set; }



    }
}
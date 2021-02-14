using AngularJsSample.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Model.MoviePersons
{
    public class MoviePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string BirthPlace { get; set; }
        public string Biography { get; set; }
        public string PhotoUrl { get; set; }
        public int Popularity { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string IMDBUrl { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public UserInfo UserLastModified { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public UserInfo UserCreated { get; set; }


    }
}

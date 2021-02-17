using AngularJsSample.Services.Messaging.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging.Views.Genres
{
    public class Genre
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public UserInfo UserLastModified { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public UserInfo UserCreated { get; set; }
    }
}

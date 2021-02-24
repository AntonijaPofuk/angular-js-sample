using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging
{
    public class DeleteMovieGenreRequest:RequestBase
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }

    }
}

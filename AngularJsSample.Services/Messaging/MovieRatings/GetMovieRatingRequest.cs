﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging
{
    public class GetMovieRatingRequest:RequestBase
    {
        public int Id { get; set; }
    }
}

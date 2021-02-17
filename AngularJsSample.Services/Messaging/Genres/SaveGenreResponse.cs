﻿using AngularJsSample.Services.Messaging.Views.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsSample.Services.Messaging.Genres
{
    public class SaveGenreResponse : ResponseBase<SaveGenreRequest>
    {
        public Genre Genre { get; set; }

    }
}

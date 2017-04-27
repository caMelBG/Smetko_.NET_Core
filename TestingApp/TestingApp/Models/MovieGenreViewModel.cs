﻿namespace TestingApp.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class MovieGenreViewModel
    {
        public List<Movie> movies;

        public SelectList genres;

        public string movieGenre { get; set; }
    }
}

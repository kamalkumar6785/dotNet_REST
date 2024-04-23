﻿using System.ComponentModel.DataAnnotations;

namespace REST.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

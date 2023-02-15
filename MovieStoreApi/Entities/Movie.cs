﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public Director Director { get; set; }
        public int DirectorId { get; set; }
        public ICollection<Actor>? Actors { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}


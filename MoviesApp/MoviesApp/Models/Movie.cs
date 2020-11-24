using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MoviesApp.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<MoviesActors>();
        }
        
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }


        public virtual ICollection<MoviesActors> Actors { get; set; }
    }
}
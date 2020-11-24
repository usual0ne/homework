using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoviesApp.Models
{
    public class MoviesActors
    {
        public MoviesActors()
        {

        }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}

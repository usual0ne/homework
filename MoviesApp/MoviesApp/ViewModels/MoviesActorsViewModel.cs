using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.ViewModels
{
    public class MoviesActorsViewModel
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}

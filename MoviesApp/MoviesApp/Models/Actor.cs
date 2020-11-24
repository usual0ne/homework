using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<MoviesActors>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public ICollection<MoviesActors> Movies { get; set; }
    }
}

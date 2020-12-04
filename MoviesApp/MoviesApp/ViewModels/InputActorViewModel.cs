using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        [Required]
        [NotShort(4)]
        public string Name { get; set; }
        [Required]
        [NotShort(4)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}

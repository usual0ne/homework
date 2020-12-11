using MoviesApp.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Services.Dto
{
    public class ActorDto
    {
        public int? Id { get; set; }

        [Required]
        [NotShort(4)]
        public string Name { get; set; }
        [Required]
        [NotShort(4, ErrorMessage = "Too short, at least 4 symbols.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EnsureActorAge(7, 99)]
        public DateTime BirthDate { get; set; }
    }
}

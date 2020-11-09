using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Betting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.GamesPlayed = new HashSet<PlayerStatistics>();
        }

        [Key]
        public int PlayerId { get; set; }

        public bool? IsInjured { get; set; }

        [Required, MaxLength(64)]
        public string Name { get; set; }

        public int? SquadNumber { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }


        public virtual ICollection<PlayerStatistics> GamesPlayed { get; set; }
    }
}

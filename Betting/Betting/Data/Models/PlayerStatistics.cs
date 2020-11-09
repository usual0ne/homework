using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Betting.Data.Models
{
    public class PlayerStatistics
    {
        public PlayerStatistics()
        {
            
        }

        public int? MinutesPlayed { get; set; }

        public int? Assists { get; set; }

        [Required]
        public int ScoredGoals { get; set; }


        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}

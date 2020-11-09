using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Betting.Data.Models
{
    public class Bet
    {
        public Bet()
        {

        }

        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Prediction Prediction { get; set; }

        public DateTime? DateTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }


        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Betting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Bets = new HashSet<Bet>();
            this.PlayersParticipants = new HashSet<PlayerStatistics>();
        }

        [Key]
        public int GameId { get; set; }

        public DateTime? DateTime { get; set; }

        [Required]
        public decimal AwayTeamBetRate { get; set; }
        [Required]
        public decimal DrawBetRate { get; set; }
        [Required]
        public decimal HomeTeamBetRate { get; set; }
        [Required]
        public Prediction Result { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }
        [Required]
        public int HomeTeamGoals { get; set; }


        [ForeignKey("HomeTeam")]
        public int? HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }


        [ForeignKey("AwayTeam")]
        public int? AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

        public virtual ICollection<PlayerStatistics> PlayersParticipants { get; set; }
    }
}

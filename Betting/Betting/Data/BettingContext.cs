using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Betting.Data.Models;

namespace Betting.Data
{
    public class BettingContext : DbContext
    {
        public BettingContext()
        {

        }

        public BettingContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistics> PlayerStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Betting;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistics>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });
            });
        }
    }
}

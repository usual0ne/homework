using System;
using Betting.Data;
using Betting.Data.Models;

namespace Betting
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BettingContext())
            {
                var country = new Country();
                country.Name = "United Kingdom";
                context.Countries.Add(country);
                context.SaveChanges();

                var town = new Town();
                town.Name = "Birmingham";
                town.CountryId = country.CountryId;
                context.Towns.Add(town);

                context.SaveChanges();
            }
        }
    }
}

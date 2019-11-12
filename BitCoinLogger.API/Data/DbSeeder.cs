using BitcoinLogger.Api.Data;
using BitcoinLogger.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Data
{
    public static class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.Database.EnsureCreated();
            if (!applicationDbContext.Sources.Any())
            {
                applicationDbContext.Sources.Add(
                    new Source
                    {
                        Name = "biststamp",
                        Endpoint = "https://www.bitstamp.net/api/ticker/"
                    });
                applicationDbContext.Sources.Add(
                    new Source
                    {
                        Name = "gdax",
                        Endpoint = "https://api.gdax.com/products/BTC-USD/ticker"
                    });
                applicationDbContext.SaveChanges();
            }
        }

    }
}


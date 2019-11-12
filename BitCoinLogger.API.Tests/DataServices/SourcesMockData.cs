using BitcoinLogger.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Tests.DataServices
{
    internal static class SourcesMockData
    {
        public static List<Source> getSourcesList()
        {
            return new List<Source>() {
                new Source
                {
                    Id = 1,
                    Name = "bitstamp",
                    Endpoint = "dummy_endpoint_1"
                },
                new Source
                {
                    Id = 2,
                    Name = "gdax",
                    Endpoint = "dummy_endpoint_2"
                }
            };
        }

        public static Source getSource()
        {
            return new Source()
            {
                Id = 1,
                Name = "bitstamp",
                Endpoint = "dummy_endpoint_1"
            };
        }

    }
}

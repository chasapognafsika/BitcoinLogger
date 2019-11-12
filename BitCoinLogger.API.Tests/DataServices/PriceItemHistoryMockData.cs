

using BitcoinLogger.Api.Data.Models;
using BitCoinLogger.API.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Tests.DataServices
{
    internal static class PriceItemHistoryMockData
    {
        public static PagedList<PriceHistoryItem> getPriceHistoryItemsList()
        { 
            return new PagedList<PriceHistoryItem>(getList(), 10, 1, 5);
        } 

        internal static List<PriceHistoryItem> getList()
        {
            return new List<PriceHistoryItem>()
            {
                new PriceHistoryItem
                {
                    Id = 1,
                    Bid = 8000,
                    SourceId = 2,
                    CreatedAt = DateTime.Now,
                    Timestamp = DateTime.Now
                },
                new PriceHistoryItem
                {
                    Id = 2,
                    Bid = 8000,
                    SourceId = 3,
                    CreatedAt = DateTime.Now,
                    Timestamp = DateTime.Now
                }
            };
        }

        public static PriceHistoryItem getPriceItem()
        { 
            return new PriceHistoryItem()
            {
                Id = 1,
                Bid = 8000,
                SourceId = 2,
                CreatedAt = DateTime.Now,
                Timestamp = DateTime.Now
            };
         }

    }
}

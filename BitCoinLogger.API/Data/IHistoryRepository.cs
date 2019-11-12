using BitcoinLogger.Api.Data.Models;
using BitCoinLogger.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Data
{
    public interface IHistoryRepository
    {
        Task<PagedList<PriceHistoryItem>> GetHistoryItems(HistoryItemParams historyItemParams);
    }

}

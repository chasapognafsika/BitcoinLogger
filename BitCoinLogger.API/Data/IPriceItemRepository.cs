using BitcoinLogger.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.Api.Data
{
    public interface IPriceItemRepository
    {
        Task<PriceHistoryItem> SavePriceItem(PriceHistoryItem item);

    }
}

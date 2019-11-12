using BitcoinLogger.Api.Data;
using BitcoinLogger.Api.Data.Models;
using BitCoinLogger.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Data
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<PriceHistoryItem>> GetHistoryItems(HistoryItemParams historyItemParams)
        {
            var historyItems = _context.PriceHistory.Include(p => p.Source).AsQueryable();

            if (historyItemParams.SourceId != 0)
            {
                historyItems = historyItems.Where(u => u.SourceId == historyItemParams.SourceId);
            }

            DateTime dateFrom;
            DateTime dateTo;

            if (DateTime.TryParse(historyItemParams.DateFrom, out dateFrom))
            {
                historyItems = historyItems.Where(u => u.Timestamp >= dateFrom);
            }

            if (DateTime.TryParse(historyItemParams.DateTo, out dateTo))
            {
                historyItems = historyItems.Where(u => u.Timestamp <= dateTo);
            }

           
            if (!string.IsNullOrEmpty(historyItemParams.OrderBy))
            {
                switch (historyItemParams.OrderBy)
                {
                    case "price":
                        historyItems = historyItems.OrderByDescending(u => u.Bid);
                        break;
                    default:
                        historyItems = historyItems.OrderByDescending(u => u.Timestamp);
                        break;
                }
            }

            return await PagedList<PriceHistoryItem>.CreateAsync(historyItems, historyItemParams.PageNumber, historyItemParams.PageSize);

        }


    }

}


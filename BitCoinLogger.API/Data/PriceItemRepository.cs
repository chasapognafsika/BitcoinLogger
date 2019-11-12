using BitcoinLogger.Api.Data;
using BitcoinLogger.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.Api.Data
{
    public class PriceItemRepository : IPriceItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PriceItemRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<PriceHistoryItem> SavePriceItem(PriceHistoryItem priceHistoryItem)
        {
            await _context.PriceHistory.AddAsync(priceHistoryItem);
            await _context.SaveChangesAsync();

            return priceHistoryItem;
        }


    }
}

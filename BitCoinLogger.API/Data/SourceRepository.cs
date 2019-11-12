using BitcoinLogger.Api.Data;
using BitcoinLogger.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Data
{
    public class SourceRepository : ISourceRepository
    {
        private readonly ApplicationDbContext _context;
        public SourceRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Source>> GetSources()
        {
            return await _context.Sources.ToListAsync();
        }

    }
}

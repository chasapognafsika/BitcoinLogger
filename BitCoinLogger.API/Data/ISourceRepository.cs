using BitcoinLogger.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Data
{
    public interface ISourceRepository
    {
        Task<List<Source>> GetSources();
    }
}

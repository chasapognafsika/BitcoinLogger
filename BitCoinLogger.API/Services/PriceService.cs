using BitcoinLogger.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Services
{
    public class PriceService : IPriceService
    {
        private HttpClient _HttpClient { get; set; }

        public PriceService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetBySourcesAsync(Source source)
        {
            if (source == null) throw new Exception("No endpoint is specified.");
            _HttpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
            return await _HttpClient.GetAsync(source.Endpoint);
        }
    }

}

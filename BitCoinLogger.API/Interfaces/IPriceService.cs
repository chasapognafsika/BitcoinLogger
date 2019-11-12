using BitcoinLogger.Api.Data.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Services
{
    public interface IPriceService
    {
        Task<HttpResponseMessage> GetBySourcesAsync(Source source);
    }
}
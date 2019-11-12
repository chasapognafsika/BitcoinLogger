using System;
using System.Threading.Tasks;
using BitcoinLogger.Api.Data.Models;
using BitcoinLogger.Api.Extensions;
using BitcoinLogger.Api.Services;
using BitCoinLogger.Api.Data;
using BitCoinLogger.API.Extensions;
using BitCoinLogger.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BitCoinLogger.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly IPriceItemRepository _priceItemRepository;

        public PricesController(IPriceService priceService, IPriceItemRepository priceItemRepository)
        {
            this._priceService = priceService;
            this._priceItemRepository = priceItemRepository;
        }

        [HttpPost]
        public async Task<ActionResult> FetchPricesBySource([FromBody] Source source)
        {
            var response = await _priceService.GetBySourcesAsync(source);
            var priceItem = Mapper.ConvertJSONToCurrecyPair(response.Content.ReadAsStringAsync().Result, source);     
            
            await _priceItemRepository.SavePriceItem(priceItem);

            //Validate if null
            if (priceItem == null)
                return NotFound(); //or any other error code accordingly. Bad request is a strong candidate also.

            return Ok(priceItem);
        }
    }
}

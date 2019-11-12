using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitCoinLogger.API.Data;
using BitCoinLogger.API.Extensions;
using BitCoinLogger.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitCoinLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryController(IHistoryRepository historyRepository)
        {
            this._historyRepository = historyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoryItems([FromQuery]HistoryItemParams historyItemParams)
        {
            var historyItems = await _historyRepository.GetHistoryItems(historyItemParams);

            Response.AddPagination(historyItems.CurrentPage, historyItems.PageSize, 
                historyItems.TotalCount, historyItems.TotalPages);

            return Ok(historyItems);
        }
    }
}
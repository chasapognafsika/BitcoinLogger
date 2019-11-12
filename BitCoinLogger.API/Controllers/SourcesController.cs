using BitcoinLogger.Api.Extensions;
using BitcoinLogger.Api.Services;
using BitCoinLogger.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BitcoinLogger.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SourcesController : ControllerBase
    {
        private readonly ISourceRepository _sourceRepository;

        public SourcesController(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }


        // GET api/Sources
        [HttpGet]
        public async Task<IActionResult> GetAllSources()
        {
            var sources = await _sourceRepository.GetSources();

            return Ok(sources);
            
        }
    }
}
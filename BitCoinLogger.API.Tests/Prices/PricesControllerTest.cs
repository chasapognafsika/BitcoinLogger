using BitCoinLogger.Api.Controllers;
using BitCoinLogger.Api.Data;
using BitCoinLogger.API.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BitCoinLogger.API.Tests
{

    public class PricesControllerTest
    {
        private Mock<IPriceItemRepository> _priceItemRepository;
        private Mock<IPriceService> _priceService;
 
        public PricesControllerTest()
        {
            InitServices();
        }

        [Fact]
        public void FetchPricesBySource_ShouldReturn_Price()
        {
            _priceItemRepository
                .Setup(x => x.SavePriceItem(DataServices.PriceItemHistoryMockData.getPriceItem()))
                .Returns(Task.FromResult(DataServices.PriceItemHistoryMockData.getPriceItem()));
            var controllerInit = new PricesController(_priceService.Object,_priceItemRepository.Object);
            var response = controllerInit.FetchPricesBySource(DataServices.SourcesMockData.getSource());
            Assert.True(response != null);
        }

        private void InitServices()
        {
            _priceService = new Mock<IPriceService>();
            _priceItemRepository = new Mock<IPriceItemRepository>();
        }

    }
}



using BitCoinLogger.API.Controllers;
using BitCoinLogger.API.Data;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BitCoinLogger.API.Tests
{

    public class HistoryControllerTest
    {
        private Mock<IHistoryRepository> _historyRepository;
        public HistoryControllerTest()
        {
            InitServices();
        }

        [Fact]
        public void GetHistoryItems_ShouldReturn_HistoryPriceItems()
        {
            _historyRepository
                .Setup(x => x.GetHistoryItems(null))
                .Returns(Task.FromResult(DataServices.PriceItemHistoryMockData.getPriceHistoryItemsList()));
            var controllerInit = new HistoryController(_historyRepository.Object);
            var response = controllerInit.GetHistoryItems(null);
            Assert.True(response != null);
        }

        private void InitServices()
        {
            _historyRepository = new Mock<IHistoryRepository>();
        }

    }
}

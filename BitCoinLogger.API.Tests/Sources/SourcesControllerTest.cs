using BitcoinLogger.Api.Controllers;
using BitCoinLogger.API.Data;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BitCoinLogger.API.Tests
{

    public class SourcesControllerTest
    {

        private Mock<ISourceRepository> _sourceRepository;
        public SourcesControllerTest()
        {
            InitServices();
        }

        [Fact]
        public void GetAllSources_ShouldReturn_Sources()
        {
            _sourceRepository
                .Setup(x => x.GetSources())
                .Returns(Task.FromResult(DataServices.SourcesMockData.getSourcesList()));

            var controllerInit = new SourcesController(_sourceRepository.Object);
            var response = controllerInit.GetAllSources();
            Assert.True(response != null);
        }

        private void InitServices()
        {
            _sourceRepository = new Mock<ISourceRepository>();
        }

    }
}

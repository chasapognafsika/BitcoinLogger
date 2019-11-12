
using BitCoinLogger.Api.Data;
using BitCoinLogger.API.Controllers;
using BitCoinLogger.API.Data;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BitCoinLogger.API.Tests
{

    public class AuthControllerTestService
    {

        private Mock<IAuthRepository> _authRepository;

        private Mock<IConfiguration> _configuration;

        public AuthControllerTestService()
        {
            InitServices();
        }

        [Fact]
        public void Register_ShouldReturn_OK()
        {
            _authRepository
                .Setup(x => x.Register(DataServices.UserMockData.getUser(),"password"))
                .Returns(Task.FromResult(DataServices.UserMockData.getUser()));

            var controllerInit = new AuthController(_authRepository.Object, _configuration.Object);
            var response = controllerInit.Register(DataServices.UserMockData.getUserForRegister());
            Assert.True(response != null);
        }

        [Fact]
        public void Login_ShouldReturn_OK()
        {
            _authRepository
                .Setup(x => x.Login("username", "password"))
                .Returns(Task.FromResult(DataServices.UserMockData.getUser()));

            var controllerInit = new AuthController(_authRepository.Object, _configuration.Object);
            var response = controllerInit.Login(DataServices.UserMockData.getUserForLogin());
            Assert.True(response != null);
        }

        private void InitServices()
        {
            _authRepository = new Mock<IAuthRepository>();
            _configuration = new Mock<IConfiguration>();
        }

    }
}

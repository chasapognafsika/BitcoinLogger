
using BitCoinLogger.Api.Data.Models;
using BitCoinLogger.API.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoinLogger.API.Tests.DataServices
{
    public static class UserMockData
    {
        public static User getUser()
        {
            return new User()
            {
                Username = "dummy",
                PasswordHash = new Byte[1000]
            };
        }

        public static UserForRegisterDto getUserForRegister()
        {
            return new UserForRegisterDto()
            {
                Username = "dummy",
                Password = "dummy"
            };
        }

        public static UserForLoginDto getUserForLogin()
        {
            return new UserForLoginDto()
            {
                Username = "dummy",
                Password = "dummy"
            };
        }
    }
}


using BitcoinLogger.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoinLogger.Api.Data.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}

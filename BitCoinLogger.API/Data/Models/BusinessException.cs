﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinLogger.Api.Data.Models
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}

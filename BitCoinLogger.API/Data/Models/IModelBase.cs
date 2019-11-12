using System;

namespace BitcoinLogger.Api.Data.Models
{
    public interface IModelBase
    {
        long Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
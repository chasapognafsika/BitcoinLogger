using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitcoinLogger.Api.Data.Models
{
    public class PriceHistoryItem : ModelBase
    {
        public long SourceId { get; set; }
        public virtual Source Source { get; set; }     
        public float Bid { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
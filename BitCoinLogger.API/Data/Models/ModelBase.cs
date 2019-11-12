using System;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Api.Data.Models
{
    public class ModelBase : IModelBase
    {
        public ModelBase()
        {
            CreatedAt = DateTime.UtcNow;
        }
        
        [Key]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
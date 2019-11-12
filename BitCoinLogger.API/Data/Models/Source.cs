using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Api.Data.Models
{
    public class Source : ModelBase
    {
        public string Name { get; set; }

        public string Endpoint { get; set; }

    }
}
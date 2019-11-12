using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitCoinLogger.API.Helpers
{
    public class HistoryItemParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int HistoryItemId { get; set; }
        public int SourceId { get; set; }
        public float Price { get; set; } 
        public string OrderBy { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

    }
}
